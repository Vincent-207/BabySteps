using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBaby : MonoBehaviour
{
    public float minColStrength;
    
    
    public int hitParticleCount = 1;
    [SerializeField]
    AudioSource hurtAudio;
    [SerializeField]
    HurtParticleManager hurtParticleManager;
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // Detect significant collisions and place particles on contacts
        if(collision.impulse.magnitude >= minColStrength)
        {
            ContactPoint[] contacts = new ContactPoint[collision.contactCount];
            collision.GetContacts(contacts);
            for(int index = 0; index < contacts.Length; index++)
            {
                Quaternion particleRotation = Quaternion.Euler(contacts[index].normal.x, contacts[index].normal.y * 90, contacts[index].normal.z);
                // Debug.Log("Placing particle!");
                hurtParticleManager.PlaceParticle(contacts[index]);
            }

        }
    }

    
}
