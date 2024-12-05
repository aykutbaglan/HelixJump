using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState : State
{
    [SerializeField] private StateMachine stateMachine;

    public override void OnEnter()
    {
        base.OnEnter();
        base.ballController.RBActiveControl(true);
        GameManager.GameResume();
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}