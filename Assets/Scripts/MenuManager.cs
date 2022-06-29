using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] Image imageToFade;
    [SerializeField] GameObject menu;

    public static MenuManager instance;

    public void Start()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    public void Update()
    {
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
        }
        else
        {
            menu.SetActive(true);
            GameManager.instance.gameMenuOpened = true;
        }
    }

    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fading");
    }

}
