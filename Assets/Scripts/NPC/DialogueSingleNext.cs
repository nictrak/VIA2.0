using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSingleNext : Dialogue
{
    [SerializeField]
    private Dialogue next;
    public override Dialogue GetNextDialogue(int param)
    {
        return next;
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
