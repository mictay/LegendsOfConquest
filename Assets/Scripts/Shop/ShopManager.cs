using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShopManager : MonoBehaviour
{

    public static ShopManager instance { get; set; }

    public GameObject shopMenu, buyPanel, sellPanel;

    [SerializeField] TextMeshProUGUI currentCoinText;

    // Start is called before the first frame update
    void Start()
    {
        if (instance && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void Update()
    {

    }

    public void OpenShopMenu()
    {
        currentCoinText.text = $"{GameManager.instance.currentCoinBalance} coins";
        ShowBuyPanel();
        shopMenu.SetActive(true);
        GameManager.instance.gameMenuOpened = true;
    }

    public void CloseShopMenu()
    {
        shopMenu.SetActive(false);
        GameManager.instance.gameMenuOpened = false;
    }

    public void ShowSellPanel()
    {
        sellPanel.SetActive(true);
        buyPanel.SetActive(false);
    }

    public void ShowBuyPanel()
    {
        sellPanel.SetActive(false);
        buyPanel.SetActive(true);
    }

}
