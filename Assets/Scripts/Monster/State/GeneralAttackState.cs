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
    private TriggerRange attackRange;
    [SerializeField]
    private bool isKnock;
    [SerializeField]
    private float knockVelocity;
    [SerializeField]
    private int knockFrame;
    [SerializeField]
    private DamageSystem.DamageSubType damageSubType;

    private int attackCounter;
    public override void ExitState()
    {
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (attackCounter >= attackFrame)
        {
            attackCounter = 0;
            //TODO do damage
            if (!attackRange.IsEmpty())
            {
                Debug.Log(GetTarget());
                GetTarget().GetComponentInParent<Health>().TakeDamage(damage, damageSubType: damageSubType);
                if (isKnock)
                {
                    PlayerKnockController knockController = GetTarget().GetComponent<PlayerKnockController>();
                    if(knockController != null) knockController.StartKnock(transform.position, knockVelocity, knockFrame);
                }
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
