using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{

    [SerializeField] Image imageToFade;
    [SerializeField] GameObject menu;

    public static MenuManager instance;

    private PlayerStats[] playerStats;
    [SerializeField] TextMeshProUGUI[] nameTexts, hpTexts, manaTexts, currentXPTexts, xpTexts;
    [SerializeField] Slider[] xpSliders;
    public Image[] characterImages;
    [SerializeField] GameObject[] characterPanels;

    private bool updatedStats = false;

    [SerializeField] GameObject defaultMenuPanelCharactersStats;

    [SerializeField] GameObject[] statsButtonCharacters;


    /** Menu : Stats **/
    [SerializeField] Image statsImageCharacter;
    [SerializeField] TextMeshProUGUI statsTextCharacterName;
    [SerializeField] TextMeshProUGUI statsTextHp;
    [SerializeField] TextMeshProUGUI statsTextMana;
    [SerializeField] TextMeshProUGUI statsTextDexterity;
    [SerializeField] TextMeshProUGUI statsTextDefense;
    [SerializeField] TextMeshProUGUI statsTextWeapon;
    [SerializeField] TextMeshProUGUI statsTextWeaponPower;
    [SerializeField] TextMeshProUGUI statsTextArmor;
    [SerializeField] TextMeshProUGUI statsTextArmorDefense;

    [SerializeField] GameObject itemSlotContainer;
    [SerializeField] Transform itemSlotContainerParent;



    public void Start()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    public void Update()
    {

        if(menu.activeInHierarchy)
        {
            GameManager.instance.gameMenuOpened = true;
            if (!updatedStats)
                UpdateCharactersStats();
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            ToggleStatsMenu();
        }
    }


    public void ToggleStatsMenu()
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
            GameManager.instance.gameMenuOpened = false;
            updatedStats = true;
        }
        else
        {
            UpdateCharactersStats();
            menu.SetActive(true);
            GameManager.instance.gameMenuOpened = true;
        }

    }

    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fading");
    }

    public void UpdateCharactersStats()
    {
        playerStats = GameManager.instance.GetPlayerStats();        

        //TURN OFF all the Panels
        for (int i = 0; i < characterPanels.Length; i++)
        {
            characterPanels[i].SetActive(false);
        }

        //TURN ON the relavant Character Stat Panels
        for (int i = 0; i < playerStats.Length; i++)
        {
            characterPanels[i].SetActive(true);
            nameTexts[i].text = playerStats[i].playerName;
            hpTexts[i].text = "HP: " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
            manaTexts[i].text = "Mana: " + playerStats[i].currentMana + "/" + playerStats[i].maxMana;
            currentXPTexts[i].text = "Current XP: " + playerStats[i].currentXP;
            xpSliders[i].maxValue = playerStats[i].xpForEachLevel[playerStats[i].playerLevel];
            xpSliders[i].value = playerStats[i].currentXP;
            xpTexts[i].text = $"{playerStats[i].currentXP}/{playerStats[i].xpForEachLevel[playerStats[i].playerLevel]}";
            xpSliders[i].interactable = false;
            characterImages[i].sprite = playerStats[i].characterSprite;
        }

        defaultMenuPanelCharactersStats.SetActive(true);
        updatedStats = true;
    }

    public void QuitGame()
    {
        Debug.Log("MenuManager Quit Game");
        Application.Quit();
    }

    public void UpdateCharacterStats()
    {

        //all off
        for (int i = 0; i < statsButtonCharacters.Length; i++)
        {
            statsButtonCharacters[i].SetActive(false);
        }

        //turn all character buttons on
        for (int i = 0; i < playerStats.Length; i++)
        {
            statsButtonCharacters[i].GetComponentInChildren<TextMeshProUGUI>().text = playerStats[i].playerName;
            statsButtonCharacters[i].SetActive(true);
            UpdateACharacterStats(i);
        }
    }

    public void UpdateACharacterStats(int i)
    {
        statsImageCharacter.sprite = playerStats[i].characterSprite;
        statsTextCharacterName.text = playerStats[i].playerName;
        statsTextHp.text = playerStats[i].currentHP.ToString();
        statsTextMana.text = playerStats[i].currentMana.ToString();
        statsTextDexterity.text = playerStats[i].dexterity.ToString();
        statsTextDefense.text = playerStats[i].defence.ToString();
        statsTextWeapon.text = "None";
        statsTextWeaponPower.text = "0";
        statsTextArmor.text = "None";
        statsTextArmorDefense.text = "0";
    }
    public void UpdateItemsInventory()
    {

        for (int i = 0; i < itemSlotContainerParent.childCount; i++)
            Destroy(itemSlotContainerParent.transform.GetChild(i).gameObject);


        foreach(ItemsManager item in Inventory.instance.GetItemsList())
        {
            //Copy the Prefab
            GameObject itemButtonFromPrefab = Instantiate(itemSlotContainer);

            //Change the Image
            itemButtonFromPrefab.transform.Find("Item Image").GetComponent<Image>().sprite = item.itemImage;

            if(item.isStackable)
                itemButtonFromPrefab.transform.Find("Item Text").GetComponent<TextMeshProUGUI>().text = item.stackSize.ToString();
            else
                itemButtonFromPrefab.transform.Find("Item Text").GetComponent<TextMeshProUGUI>().text = "";

            //Give the Grid the Item            
            itemButtonFromPrefab.transform.SetParent(itemSlotContainerParent);

            //Add the newly created object to the Grid
            //RectTransform itemSlot = Instantiate(itemSlotContainer, itemSlotContainerParent).GetComponent<RectTransform>();

        }

    }
}
