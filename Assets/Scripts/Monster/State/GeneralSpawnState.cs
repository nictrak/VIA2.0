using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GeneralSpawnState : MonsterStateBehaviour
{
    [SerializeField]
    private NeedTarget spawnedPrefab;
    [SerializeField]
    private int delayFrame;
    [SerializeField]
    private float velocity;
    [SerializeField]
    private MonsterStateMachine.MonsterState outerRangeNextState;
    [SerializeField]
    private MonsterRange outerRange;
    [SerializeField]
    private MonsterRange innerRange;

    private int delayCounter;
    private AIDestinationSetter destinationSetter;

    public override void ExitState()
    {
        
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (delayCounter >= delayFrame)
        {
            delayCounter = 0;
            NeedTarget spawned = Instantiate(spawnedPrefab);
            spawned.SetTarget(transform.position, destinationSetter.target.transform.position, velocity);
        }
        else delayCounter++;
        if (innerRange.IsHitPlayer)
        {
            return NormalNextState;
        }
        else
        {
            if (outerRange != null)
            {
                if (!outerRange.IsHitPlayer)
                {
                    return outerRangeNextState;
                }
            }
        }
        return currentState;
    }

    public override void StartState()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        delayCounter = 0;
        destinationSetter = GetComponentInParent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
