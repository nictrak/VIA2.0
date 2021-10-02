using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GeneralFollowPlayer : MonsterStateBehaviour
{
    [SerializeField]
    private TriggerRange nextStateRange;
    [SerializeField]
    private float playerEndReachedDistance;

    private AIPath aIPath;
    private AIDestinationSetter aIDestinationSetter;
    private MonsterStateMachine stateMachine;
    private float normalEndReachedDistanceBuffer;
    public override void ExitState()
    {
        stateMachine.IsUpdateDestination = true;
        aIPath.canMove = false;
        aIPath.endReachedDistance = normalEndReachedDistanceBuffer;
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (!nextStateRange.IsEmpty())
        {
            return NormalNextState;
        }
        return currentState;
    }

    public override void StartState()
    {
        stateMachine.IsUpdateDestination = false;
        aIDestinationSetter.target = Resources.FindObjectsOfTypeAll<PlayerIdentity>()[0].transform;
        aIPath.canMove = true;
        normalEndReachedDistanceBuffer = aIPath.endReachedDistance;
        aIPath.endReachedDistance = playerEndReachedDistance;
    }

    // Start is called before the first frame update
    void Start()
    {
        aIPath = GetComponentInParent<AIPath>();
        aIDestinationSetter = GetComponentInParent<AIDestinationSetter>();
        stateMachine = GetComponentInParent<MonsterStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
