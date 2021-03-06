using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralWaitState : MonsterStateBehaviour
{

    [SerializeField]
    private int delayFrame;

    private int delayCounter;
    public override void ExitState()
    {
        
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (delayCounter >= delayFrame)
        {
            delayCounter = 0;
            return NormalNextState;
        }
        else delayCounter++;
        return currentState;
    }

    public override void StartState()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        delayCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
