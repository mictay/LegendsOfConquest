using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnter : MonoBehaviour
{

    public string areaName;    

    // Start is called before the first frame update
    void Start()
    {
        
        if(Player.instance != null && areaName == Player.instance.entranceAreaName)
        {
            Player.instance.transform.position = transform.position;
        } else
        {
            Debug.Log("not setting position");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
