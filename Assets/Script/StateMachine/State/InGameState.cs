using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState : State
{
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private ObjectPoolTest objectPoolTest;

    public override void OnEnter()
    {
        base.OnEnter();
        base.ballController.RBActiveControl(true);
        GameManager.GameResume();
        objectPoolTest.StartSpawned();
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}