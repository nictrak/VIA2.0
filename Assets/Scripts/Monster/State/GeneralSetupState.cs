using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GeneralSetupState : MonsterStateBehaviour
{
    private AIDestinationSetter destinationSetter;

    public override void ExitState()
    {
        Debug.Log("Setup completed");
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        GameObject findResult = GameObject.FindGameObjectWithTag("Player");
        if(findResult != null)
        {
            destinationSetter.target = findResult.transform;
        }
        if (destinationSetter.target != null)
        {
            return NormalNextState;
        }
        return currentState;
    }

    public override void StartState()
    {
        Debug.Log("Start setup");
    }

    // Start is called before the first frame update
    void Start()
    {
        destinationSetter = GetComponentInParent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
