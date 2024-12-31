using UnityEngine;

public class LoseState : EndingState
{
    [SerializeField] private InGameState inGameState;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private ObjectPoolTest objectPoolTest;
    [SerializeField] private ObjectPool objectPool;
    public override void OnButtonClicked()
    {
        PlayerPrefs.SetInt("isGameRestarted", 1);
        PlayerPrefs.Save();
        stateMachine.TransitionToSpecificState(1);
        scoreManager.score = 0;
        scoreManager.UpdateScoreText();
        cameraController.ResetCameraTarget();
        inputController.CanvasEnable();
        objectPoolTest.StartSpawned();
        GameManager.RestartGame();
    }
}