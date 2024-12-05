using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static void GameResume()

    {
        Time.timeScale = 1f;
    }
    public static void GamePause()
    {
        Time.timeScale = 0f;
    }
    public static void LoadNextSceen()
    {
        int endSceneIndex = SceneManager.sceneCount - 1;
        int currentSceenIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceenIndex = currentSceenIndex + 1;

        if (nextSceenIndex > endSceneIndex)
        {
            nextSceenIndex = 0;
        }
        SceneManager.LoadScene(nextSceenIndex);
    }
}