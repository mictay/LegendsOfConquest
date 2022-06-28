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
        if (canActivateBox && Input.GetButtonDown("Fire1") && !DialogController.instance.IsDialogBoxActive())
        {
            Debug.Log("Hey we can activate the dialog box");
            DialogController.instance.ActivateDialog(sentences);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("DialogHandler.OnTriggerEnter2D");

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


}
