using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAttackState : MonsterStateBehaviour
{
    [SerializeField]
    private int attackFrame;
    private int attackCounter;
    public override void ExitState()
    {
        Debug.Log("Attack End");
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (attackCounter >= attackFrame)
        {
            attackCounter = 0;
            return NormalNextState;
        }
        else attackCounter++;
        return currentState;
    }

    public override void StartState()
    {
        Debug.Log("Start attack");
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
