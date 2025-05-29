using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Marax : MonoBehaviour
{
    public int HealthPoints = 50;
    public TMP_Text marax;  // Player health text
    // Start is called before the first frame update
    void Start()
    {
        marax.text = HealthPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    IEnumerator FlashText(TMP_Text textElement)
    {
        Color original = textElement.color;
        textElement.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        textElement.color = original;
    }
    public void UpdateHealth(int damage)
    {
        // Reduce player health by damage
        HealthPoints -= damage;

        // Clamp to prevent going below zero
        HealthPoints = Mathf.Max(0, HealthPoints);

        marax.text = HealthPoints.ToString();
        StartCoroutine(FlashText(marax));
    }
}
