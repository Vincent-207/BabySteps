using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBaby : MonoBehaviour
{
    public float minColStrength;
    [SerializeField]
    GameObject HitParticles;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.impulse.magnitude >= minColStrength)
        {
            Debug.Log("Hit hard! " + collision.impulse.magnitude);

        }
    }
}
