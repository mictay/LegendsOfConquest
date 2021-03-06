using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }

    [SerializeField] PlayerStats[] playerStats;

    public bool gameMenuOpened, dialogBoxOpened, gameShopMenuOpened;

    public int currentCoinBalance;

    private void Awake()
    {
        Debug.Log("GameManager Awake() called");

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager Start() called");

        //Look around and gather every game object that has a player stat
        playerStats = FindObjectsOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMenuOpened || dialogBoxOpened || gameShopMenuOpened)
        {            
            Player.instance.SetDeactivatedMovement(true);
        } else
        {
            Player.instance.SetDeactivatedMovement(false);
        }
    }

    public PlayerStats[] GetPlayerStats()
    {
        return playerStats;
    }

}
