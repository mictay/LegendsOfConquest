using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{

    public ItemsManager itemOnButton;

    public void PressMethod()
    {
        MenuManager.instance.itemName.text = itemOnButton.itemName;
        MenuManager.instance.itemDescription.text = itemOnButton.itemDescription;
        MenuManager.instance.activeItem = itemOnButton;
        Debug.Log($"ItemButton.PressMethod() called for ${itemOnButton.itemName}");
    }

}
