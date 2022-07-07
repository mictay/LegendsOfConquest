using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{

    public enum ItemType { Item, Weapon, Armor }
    public ItemType itemType;

    public string itemName, itemDescription;
    public int valueInCoins;
    public Sprite itemImage;
    public int amountOfAffect;

    public enum AffectType { HP, Mana};
    public AffectType affectType;

    public int weaponDexterity;
    public int armorDefence;

    public bool isStackable;
    public int stackSize;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log($"This item is {itemName}");
            Inventory.instance.AddItems(this);
            SelfDestroy();
        }
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void UseItem()
    {
        if(itemType == ItemType.Item)
        {

            if (affectType == AffectType.HP)
                MenuManager.instance.selectedPlayerStats.AddHP(this.amountOfAffect);

            else if (affectType == AffectType.Mana)
                MenuManager.instance.selectedPlayerStats.AddMana(this.amountOfAffect);

        }
    }

}
