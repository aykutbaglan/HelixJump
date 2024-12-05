using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : EndingState
{
    public override void OnButtonClicked()
    {
        PlayerPrefs.SetInt("inGameRestarted", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.GameResume();
    }
}