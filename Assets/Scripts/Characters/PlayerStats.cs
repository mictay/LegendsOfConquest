using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats instance { get; private set; }

    [SerializeField] string playerName;

    [SerializeField] int maxLevel = 50;

    [SerializeField] int playerLevel = 1;
    [SerializeField] int currentXP;
    [SerializeField] int[] xpForEachLevel; //xp required for each level
    [SerializeField] int baseLevelXP = 100;

    [SerializeField] int maxHP = 30;
    [SerializeField] int currentHP;

    [SerializeField] int maxMana = 30;
    [SerializeField] int currentMana;

    [SerializeField] int dexterity;

    [SerializeField] int defence;

    private void Awake()
    {
        Debug.Log("PlayerStats Awake() called");

        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

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

}
