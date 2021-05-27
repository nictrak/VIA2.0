using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GeneralAggroState : MonsterStateBehaviour
{
    [SerializeField]
    private MonsterStateMachine.MonsterState outerRangeNextState;
    [SerializeField]
    private MonsterRange outerRange;
    [SerializeField]
    private MonsterRange innerRange;
    private AIPath aiPath;
    public override void ExitState()
    {
        aiPath.canMove = false;
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (innerRange.IsHitPlayer)
        {
            return NormalNextState;
        }
        else
        {
            if(outerRange != null)
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
        aiPath.canMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponentInParent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
