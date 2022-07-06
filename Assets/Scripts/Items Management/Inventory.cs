using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<ItemsManager> itemsList;

    // Start is called before the first frame update
    void Start()
    {
        itemsList = new List<ItemsManager>();
        Debug.Log("New Inventory has been created");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItems(ItemsManager item)
    {
        itemsList.Add(item);
    }

    public void DiscardItem(ItemsManager item)
    {
        itemsList.Remove(item);
    }

}
