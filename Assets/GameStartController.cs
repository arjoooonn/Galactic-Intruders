using UnityEngine;

public class GameStartController : MonoBehaviour
{
    public GameObject buttonToToggle; // Reference to the button GameObject

    private void Start()
    {
        // Initially hide the button
        if (buttonToToggle != null)
        {
            buttonToToggle.SetActive(false); // Hide the button at the start
        }
    }

    // This method can be called to activate the button
    public void ShowButton()
    {
        if (buttonToToggle != null)
        {
            buttonToToggle.SetActive(true); // Show the button when the game starts
        }
    }
}
