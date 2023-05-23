// using UnityEngine;

// [CreateAssetMenu(fileName = "AIFighter", menuName = "AIBehaviour/AIFighter", order = 0)]
// public class AIFighter : AIBehaviour
// {
//     [SerializeField] Fighter fighter;
//     Mover mover;
//     [SerializeField] float stopDistance = 3.5f;
//     Vector2 newTargetPos = new Vector2();
// bool setNewDis = false;

//     public override bool DoAction(Transform targerPos , Transform playerPos)
//     {
//         AIPlayer aIPlayer = playerPos.GetComponent<AIPlayer>();
//         AIMover aIMover = aIPlayer.GetMover();
//         aIPlayer.EableAction(aIMover,false);
//         if (!fighter.CanAttack())
//         {   
//             if(!setNewDis)
//             {
//                  newTargetPos = playerPos.position + Vector3.up*3;
//                  setNewDis = true;
//                   mover.OnMovement(newTargetPos);
//                  mover.OnTestFighter(TryAttack);
//                  // set to random location
//                  // after rach this location try test attack
//             }
//             // bool goUp = Random.Range(1,10) == 4? true:false;
//             // Vector3 direction = new Vector3();
//             // if(goUp)
//             // {
//             //     direction = Vector3.up;
//             // }
//             // else{
//             //     direction = Vector3.down;

//             // }
//             //  mover.OnMovement(playerPos.position + Vector3.up);
//             // go up or down so he can attack player
//             return false;
//         }
//         Debug.Log("State Fighter");
        
//         fighter.Attack();
       
       



//         return true;
//     }

//     public void SetFighter(Fighter fighter, Mover mover)
//     {
//         this.fighter = fighter;
//         this.mover = mover;
//     }

//     public void TryAttack()
//     {
//          fighter.Attack();
//     }
// }