using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;
    [SerializeField] private State[] states;
    private int stateNum;
    void Start()
    {
        // ilk defa oynanýyorsa
        if (PlayerPrefs.GetInt("isGameRestarted",1) == 0)
        {
            TransitionToSpecificState(0);
        }
        else
        {
            // TO-DO[] In Game State YOK!
            TransitionToNextState();
        }
    }
    public void ChangeState(State newstate)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newstate;
        currentState.OnEnter();
    }
    public void TransitionToNextState()
    {
        if (stateNum < states.Length)
        {
            ChangeState(states[stateNum]);
            stateNum++;
        }
    }
    public void TransitionToSpecificState(int stateId)
    {
        ChangeState(states[stateId]);
        stateNum = stateId + 1;
    }
    public void CloseAllState()
    {
        for (int i = 0; i < states.Length; i++)
        {
            states[i].OnExit();
        }
    }
}