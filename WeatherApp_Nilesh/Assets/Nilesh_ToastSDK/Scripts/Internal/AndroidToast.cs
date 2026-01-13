#if UNITY_ANDROID
using UnityEngine;

internal class AndroidToast : IToastPlatform
{
    public void Show(string message)
    {
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                using (var toastClass = new AndroidJavaClass("android.widget.Toast"))
                {
                    toastClass.CallStatic<AndroidJavaObject>(
                        "makeText",
                        activity,
                        message,
                        toastClass.GetStatic<int>("LENGTH_SHORT")
                    ).Call("show");
                }
            }));
        }
    }
}
#endif
