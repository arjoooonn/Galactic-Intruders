using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkButton : MonoBehaviour
{
    public Button button; // Assign in Inspector
    public float blinkInterval = 0.5f;

    private Image buttonImage;
    private Coroutine blinkCoroutine;

    void Awake()
    {
        if (button != null)
            buttonImage = button.GetComponent<Image>();
    }

    void OnEnable()
    {
        if (button != null)
        {
            // Always re-fetch the image reference to be safe
            if (buttonImage == null)
                buttonImage = button.GetComponent<Image>();

            if (buttonImage != null)
                buttonImage.enabled = true;

            button.interactable = true;

            RestartBlinking(); // Restart the blink
        }
    }



    public void RestartBlinking()
    {
        if (button == null) return;
        if (buttonImage == null)
            buttonImage = button.GetComponent<Image>();

        if (blinkCoroutine != null)
            StopCoroutine(blinkCoroutine);

        blinkCoroutine = StartCoroutine(Blink());
    }


    IEnumerator Blink()
    {
        while (true)
        {
            if (buttonImage != null) buttonImage.enabled = false;
            button.interactable = false;

            yield return new WaitForSeconds(blinkInterval);

            if (buttonImage != null) buttonImage.enabled = true;
            button.interactable = true;

            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
