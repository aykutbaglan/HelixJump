using UnityEngine;
using UnityEngine.UI;

public class StartState : State
{
    public Button startButton;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private ObjectPoolTest objectPoolTest;
    private void OnEnable()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
    }
    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartButtonClicked);
    }
    public override void OnEnter()
    {
        base.OnEnter();
        GameManager.GamePause();
        base.ballController.RBActiveControl(false);
    }
    public override void OnExit()
    {
        base.OnExit();
    }
    public void OnStartButtonClicked()
    {
        PlayerPrefs.SetInt("isGameStarted",1);
        PlayerPrefs.Save();
        objectPoolTest.StartSpawned();
        stateMachine.TransitionToNextState();
    }
}