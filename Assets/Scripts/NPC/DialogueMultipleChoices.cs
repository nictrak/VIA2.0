using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMultipleChoices : Dialogue
{
    [SerializeField]
    private List<Dialogue> nexts;
    [SerializeField]
    private List<string> choicesString;

    public override void EndDialogue()
    {
        
    }

    public override List<string> GetChoicesString()
    {
        return choicesString;
    }

    public override Dialogue GetNextDialogue(int param)
    {
        return nexts[param];
    }

    public override bool IsClicknext()
    {
        return false;
    }

    public override void StartDialogue()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
