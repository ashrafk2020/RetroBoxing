using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : BaseState
{
    float swingDisplacement = 1.5f;
    const float tau = 2* Mathf.PI;
    float period = 1f;
    float attackTime = 0.5f;
    Vector3 statingPos;
    public FightState(Transform self, Transform target) : base(self, target)
    {
    }

    public override void EnterState()
    {
        //Enter fight state
        // Debug.Log("Fight State");
        statingPos = self.transform.position;
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        // const float amplitude = .3f;

        float cycles = Time.time / period;


        float yDisplacement = Mathf.Sin(tau * cycles);
        // yDisplacement = (yDisplacement+1)/2f;
    
        Vector3 offset = yDisplacement *Vector3.up;
        self.transform.position = statingPos + offset;



        attackTime -= Time.deltaTime;

        Vector2 direction = (target.position + offset) - self.position;

        if( Mathf.Abs(direction.x)> 0.5f && Mathf.Abs(direction.y)> 0.5f)
        {
            direction = Vector2.zero;
            statingPos = self.transform.position;
            self.GetComponent<StateMachine>().ChangeState(new IdleState(self,target));
        }

        if(fighter.CanAttack() && attackTime <0)
        {
             fighter.Attack();
        // Debug.Log("Attack ");

             attackTime = .5f;
        }
        
       
        
    }
}
