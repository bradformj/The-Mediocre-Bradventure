using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class InventoryDatabase : MonoBehaviour {

    public static InventoryDatabase Instance { get; set; }
    private List<Item> Items { get; set; }

    void Start () {

        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        BuildDatabase();

	}
	
    private void BuildDatabase()
    {
        //Builds list from JSON
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/InventoryDatabase").ToString());

    }

    public Item GetItem(string itemSlug)
    {
        foreach (Item item in Items)
        {
            if (item.ObjectSlug == itemSlug)
                return item;
        }
        Debug.LogWarning("Couldn't find item:  " + itemSlug);
        return null;
    }
}
