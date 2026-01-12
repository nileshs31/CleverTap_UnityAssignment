using UnityEngine;

internal class EditorToast : IToastPlatform
{
    public void Show(string message)
    {
        Debug.Log($"[Toast] {message}");
    }
}
