using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralFleeState : MonsterStateBehaviour
{
    [SerializeField]
    private TriggerRange fleeRange;
    private FleeController fleeController;
    private FlipToPlayer flipToPlayer;
    public override void ExitState()
    {
        fleeController.IsEnable = false ;
        flipToPlayer.IsReverse = false;
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (fleeRange.IsEmpty())
        {
            return NormalNextState;
        }
        return currentState;
    }

    public override void StartState()
    {
        fleeController.IsEnable = true;
        flipToPlayer.IsReverse = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        fleeController = GetComponentInParent<FleeController>();
        flipToPlayer = GetComponentInParent<FlipToPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
