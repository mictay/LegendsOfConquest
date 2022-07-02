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
                UpdateStats();
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
            UpdateStats();
            menu.SetActive(true);
            GameManager.instance.gameMenuOpened = true;
        }
    }

    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fading");
    }

    public void UpdateStats()
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

        updatedStats = true;
    }

    public void QuitGame()
    {
        Debug.Log("MenuManager Quit Game");
        Application.Quit();
    }

}
