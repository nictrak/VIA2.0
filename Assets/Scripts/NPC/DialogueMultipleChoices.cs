using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMultipleChoices : Dialogue
{
    [SerializeField]
    private List<Dialogue> nexts;
    [SerializeField]
    private List<string> choicesString;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
