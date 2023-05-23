using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    // [SerializeField] AIMover aiMover;
    // [SerializeField] AIFighter aiFighter;
    [SerializeField] Transform playerTransform;
    [SerializeField] Mover mover;
    [SerializeField] Fighter fighter;

     [SerializeField] StateMachine stateMachine;

    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
       
    }

    void Start()
    {
         IdleState newState = new IdleState(transform,playerTransform );
         if(newState != null)
         {
              stateMachine.ChangeState(newState);

         }
        // aiMover.SetMover(mover);
        // aiMover.SetAction = true;
        // aiFighter.SetFighter(fighter , mover);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.UpdateState();


        // if( aiMover.DoAction(playerTransform,this.transform)) return;
        // if(aiFighter.DoAction(playerTransform,this.transform)) return;
        
    }

    public void ChangeCurrentState(BaseState newState)
    {
        if (newState != null)
        {
            stateMachine.ChangeState(newState);

        }
    }

    // public void EableAction(AIBehaviour action ,bool isACTIVE)
    // {
    //     action.SetAction = isACTIVE;
    // }

//     public AIMover GetMover()
//     {
//         return aiMover;
//     }
//     public AIFighter GetAIFighter()
//     {
//         return aiFighter;
//     }
}
