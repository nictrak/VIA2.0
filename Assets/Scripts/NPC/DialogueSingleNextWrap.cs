using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSingleNextWrap : Dialogue
{
    [SerializeField]
    private string nextLevel;
    [SerializeField]
    private Condition condition;
    [SerializeField]
    private bool IsPassIfTrue;

    public override void EndDialogue()
    {
        if (!IsPassIfTrue)
        {
            WarpSystem.WarpToScene(nextLevel);
        }else if(condition.IsPass() == IsPassIfTrue){
            WarpSystem.WarpToScene(nextLevel);
        }
    }

    public override List<string> GetChoicesString()
    {
        return null;
    }

    public override Dialogue GetNextDialogue(int param)
    {
        return null;
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
