using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Consider creating 2 functions here:  character vitals and character stats that basically run the same way... or maybe making this more generic somehow.
//Consider adding a derived stat class for vitals to add the "current value" and "take damage" functionality instead of just using integers.
//Consider turnign the stats into a list of stats or dict of stats and working with them through the dictionary instead of as a bunch of variables and references.

public class CharacterStats : MonoBehaviour {

    //set up vitals
    public int maxSkin = 100; //aka health
    public int currentSkin { get; private set; }
    public int maxWind = 100; //aka stamina/fitness
    public int currentWind { get; private set; }
    public int maxPresence = 100; //aka mana
    public int currentPresence { get; private set; }

    //set up special vitals
    public int maxArmor = 10;
    public int currentArmor { get; private set; }
    public int maxArcaneShield = 10;
    public int currentArcaneShield { get; private set; }

    //set up attributes
    public Stat strength;
    public Stat agility;
    public Stat wisdom;

    //setup combat stats
    public Stat attack;
    public Stat defense;
    public Stat magicAttack;
    public Stat magicDefense;

    private void Awake()
    {
        //initialize all vitals to max
        currentSkin = maxSkin;
        currentWind = maxWind;
        currentPresence = maxPresence;

        currentArmor = maxArmor;
        currentArcaneShield = maxArcaneShield;

        //initialize the attributes
        strength = new Stat("Strength", 10);
        agility = new Stat("Agility", 11);
        wisdom = new Stat("Wisdom", 9);

        //initialize the combat stats
        attack = new Stat("Attack", 4);
        defense = new Stat("Defense", 3);
        magicAttack = new Stat("Magic Attack", 3);
        magicDefense = new Stat("Magic Defense", 3);

        //Add the basic linkers for the standard character
        attack.AddLinker(strength, .5f);

        defense.AddLinker(strength, .25f);
        defense.AddLinker(agility, .25f);

        magicAttack.AddLinker(wisdom, .5f);

        magicDefense.AddLinker(wisdom, .4f);
        magicDefense.AddLinker(agility, .2f);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //test script for debugging stat values at run time and testing the damage application function.
            //working as defined 9/10/2017, 3:05 PM
            Debug.Log(attack._statName + "'s Value = " + attack.GetValue());
            Debug.Log(defense._statName + "'s Value = " + defense.GetValue());
            Debug.Log(magicAttack._statName + "'s Value = " + magicAttack.GetValue());
            Debug.Log(magicDefense._statName + "'s Value = " + magicDefense.GetValue());

            TakeDamage(10);

        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            //test script for adding modifiers at run time, like if equipment is added or a buff is applied.
            //working as defined 9/10/2017, 3:05 PM
            attack.AddModifier(-5);
            defense.AddModifier(-5);
            Debug.Log("Adding Debuff Modifier of -5 to attack and defense");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            //test script for adding linkers at run time, like if a feat or a toggle skill allows a user to use wisom to improve defenses or something
            //working as defined 9/10/2017, 3:05 PM
            defense.AddLinker(wisdom, 5f);
            magicDefense._statEnabled = false;  //tests the toggle booleans in the stats.
            Debug.Log("You obtained the feat \"Arcane Warrior\" and your wisdom now applies massive defenses at the expense of magic defenses.");
            
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= defense.GetValue(); //clamp this so that damage can never add health


        currentSkin -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        //add a check for health < 0 to trigger die
    }

    public virtual void Die()
    {
        //do die stuff.
        Debug.Log(transform.name + " died.");
    }
    
}
