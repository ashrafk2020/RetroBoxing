using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void PlayAnimation(Animation animation)
    {
        animator.Play(animation.ToString());
        // animator.Play(Animation.Idle.ToString());
        
    }

    void ResetToIdle()
    {
        animator.Play(Animation.Idle.ToString());

    }


    public enum Animation
    {
        Idle,
        Move,
        AttackLeftHand,
        AttackRightHand,
        TakeHit
        
    }
}
