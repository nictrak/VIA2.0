using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GeneralAimState : MonsterStateBehaviour
{
    private TargetBuffer targetBuffer;
    private AIDestinationSetter aIDestinationSetter;
    public override void ExitState()
    {
        
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        targetBuffer.TargetPosition = aIDestinationSetter.target.position;
        return NormalNextState;
    }

    public override void StartState()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        targetBuffer = GetComponentInParent<TargetBuffer>();
        aIDestinationSetter = GetComponentInParent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
