using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalDialogue : Dialogue
{
    [SerializeField]
    private Dialogue trueNext;
    [SerializeField]
    private Dialogue falseNext;
    [SerializeField]
    private Condition condition;

    public override void EndDialogue()
    {
        
    }

    public override List<string> GetChoicesString()
    {
        return null;
    }

    public override Dialogue GetNextDialogue(int param)
    {
        if (condition.IsPass())
        {
            return trueNext;
        }
        return falseNext;
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
