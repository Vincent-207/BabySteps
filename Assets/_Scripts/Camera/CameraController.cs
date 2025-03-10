using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed, sensitivity;
    public Transform target;
    float xInput;
    float yInput;

    void Update()
    {
        xInput += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        yInput += Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        
    }
    void LateUpdate ()
    {
        Debug.Log("Parent Pos: " + target.position); 
        Quaternion rot = Quaternion.Euler(-yInput, xInput, 0);

        var rotation = Quaternion.LookRotation (target.position - transform.position);
        // rotation.x = 0; This is for limiting the rotation to the y axis. I needed this for my project so just
        // rotation.z = 0;                 delete or add the lines you need to have it behave the way you want.
        //Quaternion towardRot = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * speed);
        Quaternion towardRot = rotation;
        transform.rotation =  rot * towardRot;
        
    }
}
