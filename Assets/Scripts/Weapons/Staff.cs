using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }

    public Transform ProjectileSpawn { get; set; }
    Fireball fireball;
 
    private void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
        animator = GetComponent<Animator>();
    }

    public void performAttack()
    {

        animator.SetTrigger("Base_Attack");
        Debug.Log("Staff Attack!");
    }

    public void performSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
        Debug.Log("Sword Attack!");
    }

    public void CastProjectile()
    {
        Fireball fireballInstance = (Fireball)Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}
