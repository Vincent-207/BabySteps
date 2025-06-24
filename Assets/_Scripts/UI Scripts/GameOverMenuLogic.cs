using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuLogic : MonoBehaviour
{
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(GameOverManager.currentEndSceneIndex);
    }
}
