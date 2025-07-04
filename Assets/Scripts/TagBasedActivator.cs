﻿using UnityEngine;

public class TagBasedActivator : MonoBehaviour
{
    [Header("Stage Control")]
    [SerializeField] private GameObject finalStage;

    [Header("Player Reset Settings")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 resetPosition = Vector3.zero;
    [SerializeField] private bool resetPlayerVelocity = true;

    public void CheckTagCount(string tagToCheck)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tagToCheck);

        if (taggedObjects.Length <= 1)
        {
            ActivateFinalStage();
            ResetPlayerPosition();
        }
    }

    void ActivateFinalStage()
    {
        if (finalStage != null)
        {
            finalStage.SetActive(true);
        }
    }

    void ResetPlayerPosition()
    {
        if (playerTransform != null)
        {
            CharacterController cc = playerTransform.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
                playerTransform.position = resetPosition;
                cc.enabled = true;
            }
            else
            {
                playerTransform.position = resetPosition;
            }

            if (resetPlayerVelocity)
            {
                Rigidbody rb = playerTransform.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }
        }
    }
}