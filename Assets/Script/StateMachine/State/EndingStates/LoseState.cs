using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : EndingState
{
    [SerializeField] private InGameState inGameState;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private ResetLevel resetLevel;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private InputController inputController;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private ObjectPoolTest objectPoolTest;
    [SerializeField] private ObjectPool objectPool;
    public bool isRestarting = false;
    public override void OnButtonClicked()
    {
        PlayerPrefs.SetInt("isGameRestarted", 1);
        PlayerPrefs.Save();
        stateMachine.TransitionToSpecificState(1);
        scoreManager.score = 0;
        scoreManager.UpdateScoreText();
        resetLevel.ResetBallPosition();
        cameraController.ResetCameraTarget();
        inputController.CanvasEnable();
        objectPoolTest.StartSpawned();
        objectPool.StartMoving();
        GameManager.RestartGame();
    }
}