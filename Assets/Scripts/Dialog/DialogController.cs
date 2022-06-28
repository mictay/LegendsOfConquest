using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI dialogText, nameText;

    [SerializeField] GameObject dialogBox, nameBox;

    string[] dialogSentences = null;

    int currentSentence = -1;

    public static DialogController instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
            instance = this;

        Debug.Log("DialogController Start() called");

        //Just clear the last value, incase we blink-show it starting a new dialog
        ClearDialogNameText();

    }

    // Update is called once per frame
    void Update()
    {
        if(dialogBox.activeInHierarchy && dialogSentences != null && dialogSentences.Length != 0)
        {
            if(Input.GetButtonUp("Fire1"))
            {
                Debug.Log("DialogController.Update() Fire1 event");
                currentSentence++;

                if (currentSentence > dialogSentences.Length - 1)
                {
                    currentSentence = -1;
                    dialogBox.SetActive(false);

                    //Just clear the last value, incase we blink-show it starting a new dialog
                    ClearDialogNameText();

                    //Let the player move now
                    Player.instance.SetDeactivatedMovement(false);
                }
                else
                {

                    CheckForName();
                    if (currentSentence < dialogSentences.Length)
                        dialogText.text = dialogSentences[currentSentence];
                    else
                        Player.instance.SetDeactivatedMovement(false);
                }
            }

        }
    }

    public void ActivateDialog(string[] newSentencesToUse)
    {
        //Stop the player from moving while in dialog mode
        Player.instance.SetDeactivatedMovement(true);

        dialogSentences = newSentencesToUse;
        dialogBox.SetActive(true);
    }

    public bool IsDialogBoxActive()
    {
        return dialogBox.activeInHierarchy;
    }

    private void CheckForName()
    {
        if (dialogSentences[currentSentence].StartsWith("#"))
        {
            nameText.text = dialogSentences[currentSentence].Replace("#", "");
            currentSentence++;
        }
    }

    private void ClearDialogNameText()
    {
        //Just clear the last value, incase we blink-show it starting a new dialog
        dialogText.text = "";
        nameText.text = "";
    }

}
