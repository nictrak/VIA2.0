using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSingleNext : Dialogue
{
    [SerializeField]
    private Dialogue next;

    public override List<string> GetChoicesString()
    {
        return null;
    }

    public override Dialogue GetNextDialogue(int param)
    {
        return next;
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
