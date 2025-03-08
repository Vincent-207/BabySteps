using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    float startTime;
    float endTime;
    float timeToWin;
    [SerializeField]
    int nextSceneIndex = -1;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void playerEscape()
    {
        endTime = Time.time;
        timeToWin = endTime - startTime;
        Debug.Log("Won in: " + timeToWin);
        if(nextSceneIndex > 0)
        {
            Debug.Log("less than 0!");
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if(currentSceneIndex == SceneManager.sceneCountInBuildSettings -1)
            {
                currentSceneIndex = -1;
            }
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else{
            SceneManager.LoadScene(0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with something!");
        if(collision.body.CompareTag("Player"))
        {
            Debug.Log("Next Scene Index");
            playerEscape();
        }
    }

    void Update()
    {
        
    }
}
