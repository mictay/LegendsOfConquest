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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("DialogController Start() called");
        currentSentence = 0;
        dialogText.text = dialogSentence[currentSentence];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
