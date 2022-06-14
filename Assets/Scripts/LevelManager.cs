using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{

    [SerializeField] Tilemap tilemap;
    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    private static int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

        tilemap.CompressBounds();

        LevelManager.counter++;
        Debug.Log($"LevelManager Start() called {counter}");

        bottomLeftEdge = tilemap.localBounds.min + new Vector3(0.5f, 1f, 0);
        topRightEdge = tilemap.localBounds.max + new Vector3(-0.5f, -1f, 0);

        //Get the Player
        //playerTarget = GameObject.FindObjectOfType<Player>();
        Player playerTarget = Player.instance;

        playerTarget.SetLimit(bottomLeftEdge, topRightEdge);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
