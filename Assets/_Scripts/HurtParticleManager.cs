using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtParticleManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How many particle system will use.")]
    int particleCount;
    int currentParticleIndex = 0;
    [SerializeField]
    GameObject particlePrefab;
    GameObject[] particles;

    // Start is called before the first frame update
    void Start()
    {
        particles = new GameObject[particleCount];
        for(int index = 0; index < particleCount; index++)
        {
            particles[index] = Instantiate(particlePrefab, this.transform);
        }
    }
    public void PlaceParticle(ContactPoint contact)
    {
        // Debug.Log("Manager handling placement!");
        particles[currentParticleIndex].transform.position = contact.point;
        particles[currentParticleIndex].transform.rotation = Quaternion.LookRotation(contact.normal);
        particles[currentParticleIndex].GetComponentInChildren<ParticleSystem>().Play();
        incrementParticle();
    }
    public void PlaceParticle(Transform placeTransform)
    {
        particles[currentParticleIndex].transform.position = placeTransform.position;
        particles[currentParticleIndex].transform.rotation = placeTransform.rotation;
        particles[currentParticleIndex].GetComponentInChildren<ParticleSystem>().Play();
        incrementParticle();
    }
    
    void incrementParticle()
    {
        currentParticleIndex++;
        if(currentParticleIndex == particles.Length)
        {
            currentParticleIndex = 0;
        }
    }
}
