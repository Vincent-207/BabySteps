using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static int currentEndSceneIndex;
    public static int gameOverSceneIndex = 1;
    public static void GameOver()
    {
        currentEndSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(gameOverSceneIndex);
    }
}
