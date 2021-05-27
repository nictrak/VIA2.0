﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMeetState : MonsterStateBehaviour
{
    [SerializeField]
    private MonsterRange nextStateRange;
    public override void ExitState()
    {
        
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (nextStateRange.IsHitPlayer)
        {
            return NormalNextState;
        }
        return currentState;
    }

    public override void StartState()
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
