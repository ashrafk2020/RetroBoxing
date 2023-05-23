using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableBodyParts : MonoBehaviour, IDamageable
{
    [SerializeField] float damageAmount = 1f;
    [SerializeField] Health parentHealth;
    [SerializeField] AnimationController animationController;
   

    public void TakeDamage(Fighter fighter, float damage)
    {
        parentHealth.TakeDamage(fighter,damageAmount);
        // animationController.PlayAnimation(AnimationController.Animation.TakeHit);
        
    }
}