using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekState : BaseState
{
    public SeekState(Transform self, Transform target) : base(self, target)
    {
    }

    public override void EnterState()
    {
        // Debug.Log("Enter seek sTATE");


    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
        // Debug.Log("Update seek sTATE");
        Vector2 direction = (target.position + offset) - self.position;

        if (Mathf.Abs(direction.x) < 0.5f && Mathf.Abs(direction.y) < 0.5f)
        {
            direction = Vector2.zero;
            mover.OnMovement(direction.normalized);
            self.GetComponent<StateMachine>().ChangeState(new FightState(self,target));


        }

        mover.OnMovement(direction.normalized);

    }
}