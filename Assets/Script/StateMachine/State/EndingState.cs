using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingState : State
{
    public GameObject restartButtonGo;
    public Button restartButton;

    public override void OnEnter()
    {
        base.OnEnter();
        base.ballController.RBActiveControl(false);
    }
    public override void OnExit()
    {
        base.OnExit();
    }

    public void OnRestartButtonClicked()
    {
        PlayerPrefs.SetInt("inGameRestarted", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.GameResume();
    }
}
