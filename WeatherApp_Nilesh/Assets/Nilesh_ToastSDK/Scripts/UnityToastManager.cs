using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityToastManager : MonoBehaviour
{
    [SerializeField] private UnityToastView toastPrefab;

    public void Show(string message)
    {
        var toast = Instantiate(toastPrefab);
        toast.Show(message);
    }
}
