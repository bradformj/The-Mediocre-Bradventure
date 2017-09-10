using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

    void Start() {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

        //I think this function will house a ton of listeners:
        // OnFeatChange, OnAbilityAdded, OnDebuffApplied, OnBuffApplied, stuff like that... maybe this will just be some big collector of event listeners, I dunno.

    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            defense.AddModifier(newItem.armorModifier);
            attack.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            defense.RemoveModifier(oldItem.armorModifier);
            attack.RemoveModifier(oldItem.damageModifier);
        }
    }


}
