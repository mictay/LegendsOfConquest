using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats instance { get; set; }

    public string playerName;
    public Sprite characterSprite;

    [SerializeField] int maxLevel = 50;

    public int playerLevel = 1;
    public int[] xpForEachLevel; //xp required for each level
    public int baseLevelXP = 100;

    public int currentXP;

    public int maxHP = 30;
    public int currentHP;

    public int maxMana = 30;
    public int currentMana;

    public int dexterity;

    public ItemsManager weapon = null;
    public ItemsManager armor = null;

    public int defence;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

        xpForEachLevel = new int[maxLevel];
        for(int i = 0; i < maxLevel; i++)
        {
            xpForEachLevel[i] = Mathf.FloorToInt(0.02f * i * i * i + 3.06f * i * i + 105.6f * i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddXP(int amountOfXP)
    {
        currentXP += amountOfXP;

        if(currentXP > xpForEachLevel[playerLevel])
        {
            currentXP -= xpForEachLevel[playerLevel];
            playerLevel++;

            //Alternate
            if(playerLevel % 2 == 0)
            {
                dexterity++;
            } else
            {
                defence++;
            }

            maxHP = Mathf.FloorToInt(maxHP * 1.18f);
            currentHP = maxHP;

            maxMana = Mathf.FloorToInt(maxMana * 1.06f);
            currentMana = maxMana;
        }

    }


    public void AddMana(int mana)
    {

        currentMana += mana;

        if (currentMana > maxMana)
            currentMana = maxMana;

    }

    public void AddHP(int hp)
    {
        currentHP += hp;

        if (currentHP > maxHP)
            currentHP = maxHP;

    }
}
