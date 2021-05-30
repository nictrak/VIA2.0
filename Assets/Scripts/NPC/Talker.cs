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
        currentDialogue = initialDialogue;
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
        dialogueController.ShowDialogue(currentDialogue);
    }
    public bool NextTalk()
    {
        currentDialogue = currentDialogue.GetNextDialogue(0);
        Talk();
        if(currentDialogue == null)
        {
            currentDialogue = initialDialogue;
            return false;
        }
        else
        {
            return true;
        }
    }
}
