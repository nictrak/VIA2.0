using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talker : MonoBehaviour
{
    [SerializeField]
    private Dialogue initialDialogue;

    private Dialogue currentDialogue;
    private DialogueController dialogueController;
    // Start is called before the first frame update
    void Start()
    {
        SetToInitialDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        FindDialogueController();
    }
    private void FindDialogueController()
    {
        if (dialogueController == null)
        {
            GameObject finded = GameObject.FindGameObjectWithTag("HUDController");
            if (finded != null)
            {
                dialogueController = finded.GetComponent<DialogueController>();
            }
        }
    }
    public void Talk()
    {
        if(currentDialogue != null)
        {
            while (currentDialogue.IsGoNext)
            {
                currentDialogue = currentDialogue.GetNextDialogue(0);
            }
        }
        dialogueController.ShowDialogue(currentDialogue);
    }
    public bool NextTalk(int param)
    {
        currentDialogue.MakeConditionTrue();
        currentDialogue.AssignQuest();
        currentDialogue = currentDialogue.GetNextDialogue(param);
        if (currentDialogue != null)
        {
            while (currentDialogue.IsGoNext)
            {
                currentDialogue = currentDialogue.GetNextDialogue(0);
            }
        }
        Talk();
        if(currentDialogue == null)
        {
            SetToInitialDialogue();
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool IsClickNext()
    {
        return currentDialogue.IsClicknext();
    }
    public void SetToInitialDialogue()
    {
        currentDialogue = initialDialogue;
    }
}
