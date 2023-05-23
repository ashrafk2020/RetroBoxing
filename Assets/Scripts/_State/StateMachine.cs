using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    
    BaseState currentState;

    public void SetState(BaseState state)
    {
        currentState = state;
    }

    public void ChangeState(BaseState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState();

        }

        if (newState != null)
        {
            currentState = newState;

        }

        currentState.EnterState();

    }

    public void UpdateState()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public BaseState GetState()
    {
        return currentState;
    }




}
