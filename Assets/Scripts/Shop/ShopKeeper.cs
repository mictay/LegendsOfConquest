using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShopKeeper : MonoBehaviour
{

    [SerializeField] List<ItemsManager> itemsForSale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DidContactShopKeeper() && !GameManager.instance.gameShopMenuOpened)
        {
            Debug.Log("ShopKeeper.Update() Can activate the shop ui");
            ShopManager.instance.OpenShopMenu();
        }
    }

    private bool DidContactShopKeeper()
    {
        bool ret = false;

        /*        if (!Input.GetButtonDown("Fire1") && Input.touchCount == 0)
                    return ret;*/

        Vector3 pointerPosition = Vector3.zero;

        if (Input.touchCount > 0)
            pointerPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                return false;
            }
        }

        //Not sure why, but Camera.main.ScreenToWorldPoint(Input.mousePosition); set's z to -10
        pointerPosition.z = 0f;

        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();

        if (collider.bounds.Contains(pointerPosition))
        {
            ret = true;
        }

        return ret;
    }

}
