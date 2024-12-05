using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartState : State
{
    public Button startButton;
    [SerializeField] private ScoreCanvas scoreCanvas;
    [SerializeField] private StateMachine stateMachine;


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
        stateMachine.TransitionToNextState();
    }
}