// using System;
// using UnityEngine;

// [CreateAssetMenu(fileName = "AIMover", menuName = "AIBehaviour/AIMover", order = 0)]
// public class AIMover : AIBehaviour
// {
//     [SerializeField] Mover mover;
//     [SerializeField] float stopDistance = 3.5f;
//     Vector3 offset = new Vector3(3f,.2f,0);

    
//     private void Awake() {
//         SetAction = true;
//     }
//     public override bool DoAction(Transform targerPos , Transform playerPos)
//     {
        
//         Vector2 direction = (targerPos.position + offset) - playerPos.position;
       

//         if( Mathf.Abs(direction.x)< 0.5f && Mathf.Abs(direction.y)< 0.5f)
//         {
//             direction = Vector2.zero;
//             return false;
//         }


//         Debug.Log("State Moving");

//         if(SetAction)
//         {
//            mover.OnMovement(direction.normalized);
            
//         }
//         return true;
//     }

//     public void SetMover(Mover mover)
//     {
//         this.mover = mover;
//     }

    
// }