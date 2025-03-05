using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAngularChanger : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    Rigidbody[] Rigidbodies;
    [SerializeField]
    [Tooltip("max angular velocity will be set to infinty if this is set <= 0")]
    float newMaxAngularVelocity;
    void Start()
    {
        UpdateValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateValues()
    {
        for(int index = 0; index < Rigidbodies.Length; index++)
        {
            if(newMaxAngularVelocity > 0)
            {
                Rigidbodies[index].maxAngularVelocity = newMaxAngularVelocity;
            }
            else{
                Rigidbodies[index].maxAngularVelocity = Mathf.Infinity;
            }
            
        }
    }
}
