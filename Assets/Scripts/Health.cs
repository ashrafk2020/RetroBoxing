using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour,IDamageable
{
    [SerializeField] float startingHealth = 8f;
    [SerializeField] AnimationController animationController;
    float currentHealth;
    private void Awake() {
        currentHealth = startingHealth;
    }


    public void TakeDamage(Fighter attacker, float damage)
    {
        currentHealth -= damage;
        // animationController.PlayAnimation(AnimationController.Animation.TakeHit);
        //get attacker data and inform boxmanager to update score
        if (currentHealth < 0)
        {
            BoxGameManager.Instance.UpdateAttackerScore(attacker);
            currentHealth = startingHealth;

        }
    }
}
