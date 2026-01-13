using UnityEngine;

public class DemoToastButton : MonoBehaviour
{
    public string message = "Hello from Toast SDK";

    public void ShowToast()
    {
        Toast.Show(message);
    }
    public void ShowCustomToast()
    {
        Toast.ShowCustomToast(message);
    }
}
