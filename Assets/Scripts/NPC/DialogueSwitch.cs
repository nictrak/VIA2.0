using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSwitch : Dialogue
{
    [SerializeField]
    private List<Condition> conditions;
    [SerializeField]
    private List<Dialogue> dialogues;

    public override void EndDialogue()
    {

    }

    public override List<string> GetChoicesString()
    {
        return null;
    }

    public override Dialogue GetNextDialogue(int param)
    { 
        int i;
        for(i = 0; i < conditions.Count; i++)
        {
            if (conditions[i].IsPass())
            {
                return dialogues[i];
            }
        }
        return dialogues[i];
    }

    public override bool IsClicknext()
    {
        return true;
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
