using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    float startTime;
    float endTime;
    float timeToWin;

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void playerEscape()
    {
        endTime = Time.time;
    }

    void OnCllisionEnter(Collision collision)
    {
        if(collision.body.CompareTag("Player"))
        {
            playerEscape();
        }
    }

    void Update()
    {
        
    }
}
