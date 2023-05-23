using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    

    public IdleState(Transform self, Transform target) : base(self, target)
    {
    }
   

    public override void EnterState()
    {
        mover = self.GetComponent<Mover>();
        // Debug.Log("eNTER sTATE");
    }

    public override void ExitState()
    {
        // Debug.Log("Exit Idle sTATE");

    }

    public override void UpdateState()
    {
        // Debug.Log("Update sTATE");
        Vector2 direction = (target.position + offset) - self.position;

        if( Mathf.Abs(direction.x)> 0.5f || Mathf.Abs(direction.y)> 0.5f)
        {
            direction = Vector2.zero;
            self.GetComponent<StateMachine>().ChangeState(new SeekState(self,target));
        }
        
    }
}
