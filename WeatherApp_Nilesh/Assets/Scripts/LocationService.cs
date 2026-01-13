using System.Collections;
using UnityEngine;
#if UNITY_ANDROID
using UnityEngine.Android;
#endif

public class LocationService : MonoBehaviour
{
    public bool HasLocation { get; private set; }
    public float Latitude { get; private set; }
    public float Longitude { get; private set; }

    private void Start()
    {
        StartCoroutine(GetLocation());
    }

    private IEnumerator GetLocation()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            yield return new WaitForSeconds(1f);
        }
#endif

        if (!Input.location.isEnabledByUser)
        {
            Debug.LogWarning("Location not enabled, using fallback.");
            SetFallback();
            yield break;
        }

        Input.location.Start();

        int maxWait = 15;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (Input.location.status != LocationServiceStatus.Running)
        {
            Debug.LogWarning("Location failed, using fallback.");
            SetFallback();
            yield break;
        }

        Latitude = Input.location.lastData.latitude;
        Longitude = Input.location.lastData.longitude;
        HasLocation = true;

        Input.location.Stop();
    }

    private void SetFallback()
    {
        // Mumbai fallback (from assignment example)
        Latitude = 19.07f;
        Longitude = 72.87f;
        HasLocation = false;
    }
}
