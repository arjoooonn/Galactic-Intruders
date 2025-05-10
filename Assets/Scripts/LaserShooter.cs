using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public AudioClip laserSound;        // Assign in Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))  // Example: shoot when space is pressed
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        // Your laser shooting logic here (e.g., instantiate projectile)

        // Play the sound
        if (laserSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(laserSound);
        }
    }
}
