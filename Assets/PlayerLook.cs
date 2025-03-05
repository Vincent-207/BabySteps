using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Start is called before the first frame update
    Camera playerCam;
    [SerializeField]
    Transform playerCamTransform;
    public float sensitivity;
    void Start()
    {
        playerCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Mouse X") * sensitivity;
        float yInput = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(0, xInput, 0);
        playerCam.transform.Rotate(Mathf.Clamp(-yInput, -90.0f, 90.0f), 0, 0);
        
    }
}
