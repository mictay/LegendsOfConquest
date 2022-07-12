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


    public ItemsManager(ItemsManager item)
    {
        this.itemType = item.itemType;
        this.itemName = item.itemName;
        this.itemDescription = item.itemDescription;
        this.valueInCoins = item.valueInCoins;
        this.itemImage = item.itemImage;
        this.amountOfAffect = item.amountOfAffect;
        this.affectType = item.affectType;
        this.weaponDexterity = item.weaponDexterity;
        this.armorDefence = item.armorDefence;
        this.isStackable = item.isStackable;
        this.stackSize = item.stackSize;
    }

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
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    public void UseItem()
    {
        Debug.Log($"ItemsManager.UserItem() called with {this.itemName} {this.itemType}");

        //Get the PlayerStat
        PlayerStats affectedPlayerStats = MenuManager.instance.selectedPlayerStats;

        if (itemType == ItemType.Item)
        {

            if (affectType == AffectType.HP)
                affectedPlayerStats.AddHP(this.amountOfAffect);

            else if (affectType == AffectType.Mana)
                affectedPlayerStats.AddMana(this.amountOfAffect);

        } else if (itemType == ItemType.Weapon)
        {
            //Pull the existing Item
            ItemsManager weapon = affectedPlayerStats.weapon;

            //MonoBehavior doesn't support null-conditional operator
            //but does support bool
            if (weapon)
            {
                ItemsManager weaponItem = weapon;
                Debug.Log($"ItemsManager.UseItem() swapping {affectedPlayerStats.playerName}'s {weaponItem.itemType} {weaponItem.itemName}");

                //Stash the affectedPlayerStats item back into the inventory
                Inventory.instance.AddItems(weaponItem);
            }

            Debug.Log($"ItemsManager.UseItem() this is a {this.GetType()}");
            affectedPlayerStats.weapon = this;

            Debug.Log($"ItemsManager.UseItem() gave {affectedPlayerStats.playerName} weapon {this.itemName}");
            Inventory.instance.DiscardItem(this);
        }
        else if (itemType == ItemType.Armor)
        {
            //Pull the existing Item
            ItemsManager armor = affectedPlayerStats.armor;

            //MonoBehavior doesn't support null-conditional operator
            //but does support bool
            if (armor)
            {
                ItemsManager armorItem = armor;
                Debug.Log($"ItemsManager.UseItem() swapping {affectedPlayerStats.playerName}'s {armorItem.itemType} {armorItem.itemName}");

                //Stash the affectedPlayerStats item back into the inventory
                Inventory.instance.AddItems(armorItem);
            }

            Debug.Log($"ItemsManager.UseItem() this is a {this.GetType()}");
            affectedPlayerStats.armor = this;

            Debug.Log($"ItemsManager.UseItem() gave {affectedPlayerStats.playerName} weapon {this.itemName}");
            Inventory.instance.DiscardItem(this);
        }

        MenuManager.instance.UpdateCharacterStats();
    }

}
