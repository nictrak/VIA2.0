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

    private bool isShow;
    // Start is called before the first frame update
    void Start()
    {
        isShow = false;
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
    public void SetText(Dialogue dialogue)
    {
        talkerNameText.text = dialogue.TalkerName;
        dialogueText.text = dialogue.DialogueContent;
    }
    public void ShowDialogue(Dialogue dialogue)
    {
        if(dialogue == null)
        {
            SetActivePanel(false);
            isShow = false;
        }
        else
        {
            if (!isShow)
            {
                SetActivePanel(true);
            }
            SetText(dialogue);
        }
    }
    public void SetActivePanel(bool isActive)
    {
        dialoguePanel.SetActive(isActive);
        isShow = isActive;
    }
}
