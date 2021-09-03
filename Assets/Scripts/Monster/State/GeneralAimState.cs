using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GeneralAimState : MonsterStateBehaviour
{
    private TargetBuffer targetBuffer;
    public override void ExitState()
    {
        
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        targetBuffer.TargetPosition = GetTarget().transform.position;
        targetBuffer.IsAim = true;
        return NormalNextState;
    }

    public override void StartState()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        targetBuffer = GetComponentInParent<TargetBuffer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
