using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Toast
{
    private static IToastPlatform _platform;
    private static UnityToastManager _unityToastManager;

    static Toast()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _platform = new AndroidToast();
#elif UNITY_IOS && !UNITY_EDITOR
        _platform = new IOSToast();
#else
        _platform = new EditorToast();
#endif
    }

    public static void Show(string message)
    {
        if (string.IsNullOrEmpty(message))
            return;

        _platform.Show(message);
    }

    public static void ShowCustomToast(string message)
    {
        if (string.IsNullOrEmpty(message))
            return;

        if (_unityToastManager == null)
            _unityToastManager = Object.FindObjectOfType<UnityToastManager>();

        if (_unityToastManager == null)
        {
            Debug.LogWarning("UnityToastManager not found in scene.");
            return;
        }

        _unityToastManager.Show(message);
    }
}

