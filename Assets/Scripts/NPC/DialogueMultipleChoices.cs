using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMultipleChoices : Dialogue
{
    [SerializeField]
    private List<Dialogue> nexts;
    [SerializeField]
    private List<string> choicesString;
    [SerializeField]
    private List<Condition> conditions;

    private List<Dialogue> filteredNexts;
    private List<string> filteredChoicesString;

    public override void EndDialogue()
    {
        
    }

    public override List<string> GetChoicesString()
    {
        UpdateFiltered();
        return filteredChoicesString;
    }

    public override Dialogue GetNextDialogue(int param)
    {
        UpdateFiltered();
        return filteredNexts[param];
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
        filteredNexts = nexts;
        filteredChoicesString = choicesString;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void UpdateFiltered()
    {
        filteredNexts = new List<Dialogue>();
        filteredChoicesString = new List<string>();
        for(int i = 0; i < conditions.Count; i++)
        {
            if(conditions[i] == null)
            {
                filteredNexts.Add(nexts[i]);
                filteredChoicesString.Add(choicesString[i]);
            }
            else if (conditions[i].IsPass())
            {
                filteredNexts.Add(nexts[i]);
                filteredChoicesString.Add(choicesString[i]);
            }
        }
    }
}
