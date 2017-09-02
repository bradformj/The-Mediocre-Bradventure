using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour {

    public Item item;
    public InventoryController inventoryController;
    public Image icon;
    public Button removeButton;
    
    public void SetItem(Item item)
    {        
        this.item = item;

        //icon.sprite = item.icon;
        //icon.enabled = true;

        SetupItemValues();
        removeButton.interactable = true;
    }

    void SetupItemValues()
    {
        this.transform.Find("Item_Name").GetComponent<Text>().text = item.ItemName;
    }

    public void OnSelectItemButton()
    {
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
    }

    public void ClearSlot(Button removeButton)
    {
        Debug.Log("deleted.");
    }

    public void OnRemoveButton()
    {
        //stuff
    }
}
