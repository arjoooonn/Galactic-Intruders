using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonBlinker : MonoBehaviour
{
    public float blinkInterval = 0.5f;

    private Image image;
    private Button button;
    private Coroutine blinkCoroutine;

    void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    void OnEnable()
    {
        if (image != null)
            image.enabled = true;

        if (button != null)
            button.interactable = true;

        if (blinkCoroutine != null)
            StopCoroutine(blinkCoroutine);

        blinkCoroutine = StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            if (image != null) image.enabled = false;
            if (button != null) button.interactable = false;

            yield return new WaitForSeconds(blinkInterval);

            if (image != null) image.enabled = true;
            if (button != null) button.interactable = true;

            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
