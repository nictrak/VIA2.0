using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    private Text talkerNameText;
    [SerializeField]
    private Text dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetText(string talkerName, string dialogue)
    {
        talkerNameText.text = talkerName;
        dialogueText.text = dialogue;
    }
    public void SetActivePanel(bool isActive)
    {
        dialoguePanel.SetActive(isActive);
    }
}
