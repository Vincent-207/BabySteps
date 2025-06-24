using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnCol : MonoBehaviour
{
    public int sceneBuildIndex = 0;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }

    public void load(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
