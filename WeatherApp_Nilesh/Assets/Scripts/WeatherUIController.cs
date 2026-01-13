using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WeatherUIController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LocationService locationService;
    [SerializeField] private WeatherService weatherService;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI temperatureText;

    public void OnGetWeatherButtonClicked(bool isNative)
    {
        if (locationService == null || weatherService == null)
        {
            Debug.LogError("WeatherUIController: Missing references.");
            return;
        }

        float lat = locationService.Latitude;
        float lon = locationService.Longitude;

        temperatureText.text = "Fetching weather...";

        if (isNative)
            StartCoroutine(
                weatherService.GetWeather(
                    lat,
                    lon,
                    OnWeatherSuccessNative,
                    OnWeatherFailureNative
                )
            );
        else
            StartCoroutine(
                weatherService.GetWeather(
                    lat,
                    lon,
                    OnWeatherSuccessCustom,
                    OnWeatherFailureCustom
                )
            );
    }

    private void OnWeatherSuccessNative(float temperature)
    {
        float lat = locationService.Latitude;
        float lon = locationService.Longitude;

        temperatureText.text =
            $"Latitude: {lat:F4}\n" +
            $"Longitude: {lon:F4}\n" +
            $"Temperature: {temperature}°C";

        Toast.Show($"Current Temperature: {temperature}°C");
    }

    private void OnWeatherFailureNative(string error)
    {
        string message = "Failed to fetch weather.";

        temperatureText.text = message;
        Debug.LogError(error);

        Toast.Show(message);
    }

    private void OnWeatherSuccessCustom(float temperature)
    {
        float lat = locationService.Latitude;
        float lon = locationService.Longitude;

        temperatureText.text =
            $"Latitude: {lat:F4}\n" +
            $"Longitude: {lon:F4}\n" +
            $"Temperature: {temperature}°C";

        Toast.ShowCustomToast($"Current Temperature: {temperature}°C");
    }

    private void OnWeatherFailureCustom(string error)
    {
        string message = "Failed to fetch weather.";

        temperatureText.text = message;
        Debug.LogError(error);

        Toast.ShowCustomToast(message);
    }
}
