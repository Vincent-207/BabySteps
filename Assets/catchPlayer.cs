using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchPlayer : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("Found Player!");
            GameOverManager.GameOver();
        }

    }
}
