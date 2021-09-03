using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public abstract class MonsterStateBehaviour : MonoBehaviour
{
    [SerializeField]
    protected MonsterStateMachine.MonsterState currentState;
    public MonsterStateMachine.MonsterState NormalNextState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public abstract void ExitState();
    public abstract void StartState();
    public abstract MonsterStateMachine.MonsterState RunState();

    protected GameObject GetTarget()
    {
        return GetComponentInParent<AIDestinationSetter>().target.gameObject;
    }
    protected bool IsTriggerRangeContainTarget(TriggerRange range)
    {
        return range.Objs.Contains(GetTarget());
    }
}
