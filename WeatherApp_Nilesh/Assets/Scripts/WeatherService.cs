using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherService : MonoBehaviour
{
    private const string BASE_URL =
        "https://api.open-meteo.com/v1/forecast";

    public IEnumerator GetWeather(
        float latitude,
        float longitude,
        Action<float> onSuccess,
        Action<string> onFailure)
    {
        string url =
            $"{BASE_URL}?latitude={latitude}&longitude={longitude}&timezone=IST&daily=temperature_2m_max";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                onFailure?.Invoke(request.error);
                yield break;
            }

            try
            {
                WeatherResponse response =
                    JsonUtility.FromJson<WeatherResponse>(request.downloadHandler.text);

                if (response.daily.temperature_2m_max.Length > 0)
                {
                    float temperature = response.daily.temperature_2m_max[0];
                    onSuccess?.Invoke(temperature);
                }
                else
                {
                    onFailure?.Invoke("No temperature data available.");
                }
            }
            catch (Exception e)
            {
                onFailure?.Invoke(e.Message);
            }
        }
    }

    #region JSON Models

    [Serializable]
    private class WeatherResponse
    {
        public Daily daily;
    }

    [Serializable]
    private class Daily
    {
        public float[] temperature_2m_max;
    }

    #endregion
}
