using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GeneralAttackState : MonsterStateBehaviour
{
    [SerializeField]
    private int attackFrame;
    [SerializeField]
    private int damage;
    [SerializeField]
    private MonsterRange attackRange;

    private int attackCounter;
    private AIDestinationSetter aIDestinationSetter;
    public override void ExitState()
    {
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (attackCounter >= attackFrame)
        {
            attackCounter = 0;
            //TODO do damage
            if (attackRange.IsHitPlayer)
            {
                aIDestinationSetter.target.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
            return NormalNextState;
        }
        else attackCounter++;
        return currentState;
    }

    public override void StartState()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        attackCounter = 0;
        aIDestinationSetter = GetComponentInParent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
