using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void performAttack()
    {
        animator.SetTrigger("Base_Attack");
        Debug.Log("Sword Attack!");
    }

    public void performSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
        Debug.Log("Sword Attack!");
    }

    private void OnTriggerEnter(Collider colEnemy)
    {

        Debug.Log("Hit: " + colEnemy.name);

        if (colEnemy.tag == "Enemy")
        {
            colEnemy.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue()); //This needs to be better:  currently only uses the weapon "power"
        }

    }
}
