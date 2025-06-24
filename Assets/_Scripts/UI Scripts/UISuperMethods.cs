using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISuperMethods : MonoBehaviour
{
    public static int firstLevelBuildIndex = 2;
    public GameObject settingsPanel;
    public  void loadFirstLevel()
    {
        SceneManager.LoadScene(firstLevelBuildIndex);
    }

    public void toggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

}
