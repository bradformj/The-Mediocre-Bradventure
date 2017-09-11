using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public int armorModifier;
    public int damageModifier;

    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer sMesh;
    public MeshRenderer mesh;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();

    }
}

public enum EquipmentSlot {Head, Chest, Legs, Hands, Feet, MainHand, OffHand}
