using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int Bosshealth = 100;
    public TMP_Text kruger;    // Boss health text

    void Start()
    {
        // Initialize UI text with starting values
        kruger.text = Bosshealth.ToString();
    }
    IEnumerator FlashText(TMP_Text textElement)
    {
        Color original = textElement.color;
        textElement.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        textElement.color = original;
    }

    public void UpdateBossHealth(int damage)
    {
        // Reduce boss health by damage
        Bosshealth -= damage;

        // Clamp to prevent going below zero
        Bosshealth = Mathf.Max(0, Bosshealth);

        kruger.text = Bosshealth.ToString();
        StartCoroutine(FlashText(kruger));
    }
}


