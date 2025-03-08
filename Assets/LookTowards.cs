using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowards : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed;
    public Transform target;

    void LateUpdate ()
    {
        Debug.Log("Parent Pos: " + target.position); 
        var rotation = Quaternion.LookRotation (target.position - transform.position);
        // rotation.x = 0; This is for limiting the rotation to the y axis. I needed this for my project so just
        // rotation.z = 0;                 delete or add the lines you need to have it behave the way you want.
        transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * speed);
    }
}
