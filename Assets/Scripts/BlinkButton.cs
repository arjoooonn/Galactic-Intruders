using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkButton : MonoBehaviour
{
    public Button button;                 // Assign this in the Inspector
    public float blinkInterval = 0.5f;    // Time between blinks in seconds

    void Start()
    {
        if (button != null)
        {
            StartCoroutine(Blink());
        }
        else
        {
            Debug.LogError("Button reference is not assigned!");
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            button.gameObject.SetActive(false);
            yield return new WaitForSeconds(blinkInterval);
            button.gameObject.SetActive(true);
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}

