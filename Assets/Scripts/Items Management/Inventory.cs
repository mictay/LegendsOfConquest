using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<ItemsManager> itemsList;

    public static Inventory instance { get; private set; }

    private void Awake()
    {
        Debug.Log("Inventory Awake() called");

        if (instance && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;

            if(instance.itemsList == null)
                itemsList = new List<ItemsManager>();

        }
    }

    // Start is called before the first frame update
    void Start()
    {        
        Debug.Log("New Inventory has been created");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItems(ItemsManager item)
    {
        
        if(item.isStackable)
        {
            bool itemFound = false;
            foreach(ItemsManager itemInInventory in itemsList)
            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.stackSize += item.stackSize;
                    itemFound = true;
                }
            }

            if (!itemFound)
            {
                itemsList.Add(item);
            }

        } else
        {
            itemsList.Add(item);
        }

        Debug.Log($"{item.itemName} was added to the list count={itemsList.Count}");
    }

    public void DiscardItem(ItemsManager item)
    {
        itemsList.Remove(item);
    }

    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }

}
