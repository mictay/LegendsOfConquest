using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHandler : MonoBehaviour
{

    public string[] sentences;
    private bool canActivateBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DidContactNPC() && !DialogController.instance.IsDialogBoxActive())
        {
            Debug.Log("Hey we can activate the dialog box");
            DialogController.instance.ActivateDialog(sentences);
        }
    }

/*    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Hi quinn, DialogHandler.OnTriggerEnter2D");

        if (collision.CompareTag("Player"))
        {
            canActivateBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("DialogHandler.OnTriggerExit");

        if (collision.CompareTag("Player"))
        {
            canActivateBox = false;
        }
    }

*/    private bool DidContactNPC()
    {
        bool ret = false;

/*        if (!Input.GetButtonDown("Fire1") && Input.touchCount == 0)
            return ret;*/

        Vector3 pointerPosition = Vector3.zero;

        if (Input.touchCount > 0)
            pointerPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        else
        {
            if (Input.GetButtonDown("Fire1")) {
                pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            } else {
                return false;
            }
        }

        //Not sure why, but Camera.main.ScreenToWorldPoint(Input.mousePosition); set's z to -10
        pointerPosition.z = 0f;

        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();        

        if (collider.bounds.Contains(pointerPosition)) {
            ret = true;            
        }

        return ret;
    }

}
