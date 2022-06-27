using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI dialogText, nameText;

    [SerializeField] GameObject dialogBox, nameBox;

    [SerializeField] string[] dialogSentence;

    [SerializeField] int currentSentence;

    public static DialogController instance;

    // Start is called before the first frame update
    void Start()
    {

        instance = this;

        Debug.Log("DialogController Start() called");
        currentSentence = 0;
        dialogText.text = dialogSentence[currentSentence];
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogBox.activeInHierarchy)
        {
            if(Input.GetButtonUp("Fire1"))
            {
                currentSentence++;

                if (currentSentence > dialogSentence.Length - 1)
                {
                    currentSentence = 0;
                    dialogBox.SetActive(false);
                }
                else
                {
                    dialogText.text = dialogSentence[currentSentence];
                }
            }

        }
    }
}
