using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Interactable, IEnemy
{
    public float currentHealth, power, toughness;
    public float maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void PerformAttack()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth<=0)
        {
            enemyDie();
        }

    }

    void enemyDie()
    {
        Destroy(gameObject);
    }
}
