using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform player;
    [SerializeField]
    float sensitivity = 1;
    Camera cam;
    public Vector3 lookOffset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Mouse X");
        float yInput = Input.GetAxis("Mouse Y");


    }

    void LateUpdate()
    {
        Vector3 toPlayer = player.position - transform.position;
        toPlayer *= .5f * Time.deltaTime;
        transform.position += toPlayer + lookOffset;
        transform.LookAt(player);
    }
}
