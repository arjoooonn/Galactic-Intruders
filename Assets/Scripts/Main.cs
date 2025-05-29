using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject startButton; // Declare the button at the class level

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1); // Load the next scene
    }

    public void PlayAgain()
    {
        // Check if the startButton is not null and activate it
        if (startButton != null)
        {
            startButton.SetActive(true);
        }

        SceneManager.LoadSceneAsync(0); // Load the starting scene
    }

    void Start()
    {
        // You can initialize things in the Start method if needed
    }
}

