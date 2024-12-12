using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : EndingState
{
    [SerializeField] private InGameState inGameState;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private ResetLevel resetLevel;
    [SerializeField] private CameraController cameraController;
    public bool isRestarting = false;
    public override void OnButtonClicked()
    {
       // isRestarting = true;

        PlayerPrefs.SetInt("isGameRestarted", 1);
        PlayerPrefs.Save();
        stateMachine.TransitionToSpecificState(1);
        //base.OnEnter();
        resetLevel.ResetBallPosition();
        cameraController.ResetCameraTarget();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}