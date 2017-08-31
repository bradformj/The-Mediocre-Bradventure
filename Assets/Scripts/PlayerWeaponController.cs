using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

    public GameObject playerHand;

    public GameObject EquippedWeapon { get; set; }

    Transform spawnProjectile;
    IWeapon equippedWeapon;
    StatsCharacter characterStats;

    private void Start()
    {
        spawnProjectile = transform.Find("ProjectileSpawn");
        characterStats = GetComponent<StatsCharacter>();
        
    }

    public void EquipWeapon(Item itemToEquip)

    {
        if (EquippedWeapon != null)
        {
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }

        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();

        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }
        
        EquippedWeapon.GetComponent<IWeapon>().Stats = itemToEquip.Stats;
        EquippedWeapon.transform.SetParent(playerHand.transform);

        characterStats.AddStatBonus(itemToEquip.Stats);

        foreach (BaseStat stat in characterStats.stats)
        {
            Debug.Log("Final " + stat.StatName + " Value is: " + stat.GetCalculatedStatValue());

        }
        
    }

    private void Update() { 
    
        if(Input.GetKeyDown(KeyCode.X))
        {
            PerformWeaponAttack();
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            PerformWeaponSpecialAttack();
        }
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.performAttack();
    }

    public void PerformWeaponSpecialAttack()
    {
        equippedWeapon.performSpecialAttack();
    }
}
