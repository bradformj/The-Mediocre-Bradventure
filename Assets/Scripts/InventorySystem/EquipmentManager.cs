using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    public Equipment[] currentEquipment;
    public SkinnedMeshRenderer[] currentSMeshes;
    public MeshRenderer[] currentMeshes;

    public SkinnedMeshRenderer targetSMesh;
    public SkinnedMeshRenderer targetLHMesh;
    public SkinnedMeshRenderer targetRHMesh;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];

        currentSMeshes = new SkinnedMeshRenderer[numSlots];
        currentMeshes = new MeshRenderer[numSlots];

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        currentEquipment[slotIndex] = newItem;

        if(newItem.sMesh != null)
        {
            SkinnedMeshRenderer newSMesh = Instantiate<SkinnedMeshRenderer>(newItem.sMesh);
            newSMesh.transform.parent = targetSMesh.transform;

            newSMesh.bones = targetSMesh.bones;
            newSMesh.rootBone = targetSMesh.rootBone;
            currentSMeshes[slotIndex] = newSMesh;
        }


        if (newItem.mesh != null)
        {
            if (slotIndex == 5)
            {
                MeshRenderer newMesh = Instantiate<MeshRenderer>(newItem.mesh);
                newMesh.transform.parent = targetRHMesh.transform;
                newMesh.transform.position = targetRHMesh.transform.position;
                newMesh.transform.localRotation = targetLHMesh.transform.localRotation;

                Vector3 rot = newMesh.transform.localEulerAngles;
                rot.x = -newMesh.transform.localEulerAngles.z;
                Quaternion newOrientation = Quaternion.Euler(rot);

                newMesh.transform.localRotation = newOrientation;

                currentMeshes[slotIndex] = newMesh;

            }


            if (slotIndex == 6)
            {
                MeshRenderer newMesh = Instantiate<MeshRenderer>(newItem.mesh);
                newMesh.transform.parent = targetLHMesh.transform;
                newMesh.transform.position = targetLHMesh.transform.position;
                newMesh.transform.localRotation = targetLHMesh.transform.localRotation;

                Vector3 rot = newMesh.transform.localEulerAngles;
                rot.x = -newMesh.transform.localEulerAngles.z;
                Quaternion newOrientation = Quaternion.Euler(rot);

                newMesh.transform.localRotation = newOrientation;

                currentMeshes[slotIndex] = newMesh;
            }
        }
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            
            if(currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            if (currentSMeshes[slotIndex] != null)
            {
                Destroy(currentSMeshes[slotIndex].gameObject);
            }

            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }
}
