using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    public GameObject finalStage;   // Assign the "FinalStage" GameObject here
    public GameObject winCanvas;    // Assign your "You Win" canvas here

    private Transform kruger;
    private Transform marax;
    private Transform marax1;

    private bool hasWon = false;

    void Start()
    {
        if (finalStage != null)
        {
            kruger = finalStage.transform.Find("KRUGER");
            marax = finalStage.transform.Find("marax");
            marax1 = finalStage.transform.Find("marax (1)");

            // Optional Debug:
            if (kruger == null || marax == null || marax1 == null)
                Debug.LogWarning("One or more enemies not found as children of FinalStage!");
        }
        else
        {
            Debug.LogError("FinalStage is not assigned in the inspector!");
        }
    }

    void Update()
    {
        if (!hasWon &&
            (kruger == null || !kruger.gameObject) &&
            (marax == null || !marax.gameObject) &&
            (marax1 == null || !marax1.gameObject))
        {
            hasWon = true;
            winCanvas.SetActive(true); // Activate win UI
            Time.timeScale = 0f;       // Pause the game (optional)
        }
    }
}

