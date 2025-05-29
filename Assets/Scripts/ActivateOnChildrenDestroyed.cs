using UnityEngine;

public class ActivateOnChildrenDestroyed : MonoBehaviour
{
    public GameObject finalStage; // Assign "Final-Stage" in Inspector

    private void Start()
    {
        // If no enemies exist at start, activate Final-Stage immediately
        if (transform.childCount == 0)
        {
            ActivateFinalStage();
        }
    }

    private void Update()
    {
        // Check every frame if all child enemies are gone
        if (transform.childCount == 0)
        {
            ActivateFinalStage();
        }
    }

    private void ActivateFinalStage()
    {
        // Deactivate the Enemies parent
        gameObject.SetActive(false);

        // Activate Final-Stage if assigned
        if (finalStage != null)
        {
            finalStage.SetActive(true);
        }

        // Disable this script to stop checking
        enabled = false;
    }
}