using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blinkers : MonoBehaviour
{
    public RawImage Win;            // Assign in the Inspector
    public float blinkInterval = 0.3f;
    public float endTime = 10f;

    private Coroutine blinkCoroutine;

    void OnEnable()
    {
        if (Win != null)
        {
            // Start blinking when the GameObject becomes active
            blinkCoroutine = StartCoroutine(Blink());
        }
        else
        {
            Debug.LogError("RawImage reference is not assigned!");
        }
    }

    void OnDisable()
    {
        // Stop the coroutine if the object is disabled mid-blink
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
        }

        // Optionally reset visibility when disabled
        if (Win != null)
            Win.enabled = true;
    }

    IEnumerator Blink()
    {
        float timer = 0f;

        while (timer < endTime)
        {
            Win.enabled = false;
            yield return new WaitForSeconds(blinkInterval);

            Win.enabled = true;
            yield return new WaitForSeconds(blinkInterval);

            timer += blinkInterval * 2;
        }

        Win.enabled = true; // Final state: visible
    }
}


