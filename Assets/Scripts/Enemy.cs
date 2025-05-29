using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyTag = "Enemy";

    private void OnDestroy()
    {
        // Notify the TagManager when destroyed
        TagBasedActivator manager = FindObjectOfType<TagBasedActivator>();
        if (manager != null)
        {
            manager.CheckTagCount(enemyTag);
        }
    }
}
