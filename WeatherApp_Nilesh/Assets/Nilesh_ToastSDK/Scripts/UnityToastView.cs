using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class UnityToastView : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private float fadeDuration = 0.25f;
    [SerializeField] private float visibleDuration = 2f;

    public void Show(string message)
    {
        messageText.text = message;
        StartCoroutine(ToastRoutine());
    }

    private IEnumerator ToastRoutine()
    {
        // Fade in
        yield return Fade(0, 1);

        // Stay
        yield return new WaitForSeconds(visibleDuration);

        // Fade out
        yield return Fade(1, 0);

        Destroy(gameObject);
    }

    private IEnumerator Fade(float from, float to)
    {
        float t = 0f;
        canvasGroup.alpha = from;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(from, to, t / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = to;
    }
}
