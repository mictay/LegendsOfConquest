using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }

    [SerializeField] PlayerStats[] playerStats;

    public bool gameMenuOpened, dialogBoxOpened;

    private void Awake()
    {
        Debug.Log("GameManager Awake() called");

        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        //Look around and gather every game object that has a player stat
        playerStats = FindObjectsOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMenuOpened || dialogBoxOpened)
        {
            Player.instance.SetDeactivatedMovement(true);
        } else
        {
            Player.instance.SetDeactivatedMovement(false);
        }
    }
}
