using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blinkitt : MonoBehaviour
{
    public Image Alert;                 
    public float blinkInterval = 0.3f;
    public float endTime = 3f;

    void Start()
    {
        if (Alert != null)
        {
            StartCoroutine(Blink());
            StartCoroutine(StopAndDestroy());
        }
        else
        {
            Debug.LogError("Image reference is not assigned!");
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            Alert.gameObject.SetActive(false);
            yield return new WaitForSeconds(blinkInterval);
            Alert.gameObject.SetActive(true);
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    IEnumerator StopAndDestroy()
    {
        yield return new WaitForSeconds(endTime);

        StopAllCoroutines();

 
        Destroy(Alert.gameObject);
    }
}

