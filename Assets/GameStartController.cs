using UnityEngine;

public class GameStartController : MonoBehaviour
{
    public GameObject buttonToToggle; // Reference to the button GameObject

    private void Start()
    {

    }

    // Call this when you want the button to appear and blink
    public void ShowButton()
    {
        if (buttonToToggle != null)
        {
            buttonToToggle.SetActive(true); // Re-enables the GameObject
            BlinkButton blinker = buttonToToggle.GetComponent<BlinkButton>();
            if (blinker != null)
            {
                blinker.RestartBlinking(); // Safe and clean blink restart
            }
        }
    }
}
