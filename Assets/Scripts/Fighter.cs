using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] Transform leftHand;
    [SerializeField] Transform rightHand;
    [SerializeField] float attackDistance = 3f;
    [SerializeField] Transform playerTransform;
    [SerializeField]  bool isLeftPlayer = true;
    [SerializeField]  bool isAIPlayer = false;
    [SerializeField] LayerMask hittableLayer;
    [SerializeField] AnimationController animationController;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hitClip;
     bool canAttackRightHand;
    bool canAttackLeftHand;

    IDamageable target;
    bool gameFinished;

    public void SetPlayerSide(bool isLeft)
    {
        isLeftPlayer = isLeft;
    }

    private void Start() {
         BoxGameManager.Instance.OnPlayerWins +=BoxGameManager_OnPlayerWins;
    }

    private void BoxGameManager_OnPlayerWins(object sender, string e)
    {
        gameFinished = true;
    }

    void Update()
    {


        RaycastHit2D raycastHit2DLeft = Physics2D.Raycast(leftHand.position, GetDirection(), attackDistance, hittableLayer);
        RaycastHit2D raycastHit2DRight = Physics2D.Raycast(rightHand.position, GetDirection(), attackDistance, hittableLayer);

        if (raycastHit2DLeft.collider != null)
        {
            IDamageable damageable = raycastHit2DLeft.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                canAttackLeftHand = true;
                target = damageable;
                //    Debug.Log(gameObject.name+"see a target at hand" + leftHand.name);
            }
           

        }



        else if (raycastHit2DRight.collider != null)
        {
            IDamageable damageable = raycastHit2DRight.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                //    Debug.Log(gameObject.name+ "see a target at hand" + rightHand.name);
                canAttackRightHand = true;
                target = damageable;
            }
            

        }
        else
        {
            target = null;
            canAttackRightHand = false;
            canAttackLeftHand = false;

            // 
        }

        if (isAIPlayer || gameFinished) return;
        HandleAttack();
    }

    private void HandleAttack()
    {
        if (GetPlayerLeft())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Attack();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                Attack();
            }


        }

    }

    public void Attack()
    {
        if(gameFinished) return;
        if (CanAttack())
        {
            // canAttackLeftHand = UnityEngine.Random.Range(1,50) == 5? true:false;
            if (canAttackLeftHand)
            {
                if (isLeftPlayer)
                {
                    animationController.PlayAnimation(AnimationController.Animation.AttackRightHand);

                }
                else
                {
                    animationController.PlayAnimation(AnimationController.Animation.AttackLeftHand);

                }
            }
            else if (canAttackRightHand)
            {
                if (isLeftPlayer)
                {
                    animationController.PlayAnimation(AnimationController.Animation.AttackLeftHand);

                }
                else
                {
                    animationController.PlayAnimation(AnimationController.Animation.AttackRightHand);

                }

            }
            if (target != null)
            {
                target.TakeDamage(this,1f);
                audioSource.PlayOneShot(hitClip);
                // target = null;
// 
                // play hit sound

            }

        }
        else
        {
            target = null;
            animationController.PlayAnimation(AnimationController.Animation.Idle);

        }

    }

    public bool CanAttack()
    {
        return !(canAttackRightHand && canAttackLeftHand) && target !=null;
        // return true;
    }

    public Vector3 GetDirection()
    {
        return isLeftPlayer ? Vector2.right : Vector2.left;
    }

    public bool GetPlayerLeft()
    {
        return isLeftPlayer;
    }
    public bool GetPlayerRight()
    {
        return isLeftPlayer == false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(leftHand.position, leftHand.position + GetDirection() * attackDistance);
        Gizmos.DrawCube(leftHand.position, new Vector2(1, 1));
        Gizmos.DrawCube(rightHand.position, new Vector2(1, 1));
    }
}
