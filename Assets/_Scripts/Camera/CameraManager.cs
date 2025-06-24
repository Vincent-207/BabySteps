using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] cameras;
    [SerializeField]
    Transform player;
    int currentCamIndex = 0;
    public float[] distances;
    // Start is called before the first frame update
    void Start()
    {
        disableAllCameras();
        distances = new float[cameras.Length];
        currentCamIndex = getClosestCam();
        enableCamComponent(currentCamIndex, true);
    }

    // Update is called once per frame
    void Update()
    {
        int closestCamIndex = getClosestCam();
        if(closestCamIndex != currentCamIndex)
        {
            currentCamIndex = closestCamIndex;
            disableAllCameras();
            enableCamComponent(closestCamIndex, true);
        }
    }
    void enableCamComponent(int index, bool setEnable = true)
    {
        cameras[index].GetComponent<Camera>().enabled = setEnable;
        cameras[index].GetComponent<AudioListener>().enabled = setEnable;
    }

    void disableAllCameras()
    {
        for(int index = 0; index < cameras.Length; index++)
        {
            enableCamComponent(index, false);
        }
    }
    

    int getClosestCam()
    {
        int lowestLengthIndex = 0;
        // Debug.Log("PLayer pos: " + player.position);
        float lowestSqrDistance = (player.position - cameras[0].transform.position).sqrMagnitude;
        for(int index = 0; index < cameras.Length; index++)
        {
            
            Vector3 toPlayer = player.position - cameras[index].transform.position;
            float sqrDistance = toPlayer.sqrMagnitude;
            distances[index] = sqrDistance;
            if(sqrDistance < lowestSqrDistance)
            {
                lowestLengthIndex = index;
            }
        }

        // Debug.Log("Getting closest cam(" + lowestLengthIndex + ")!");
        return lowestLengthIndex;
    }
}
