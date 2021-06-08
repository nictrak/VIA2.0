using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBossAttack : BossStateBehaviour
{
    [SerializeField]
    private int attackFrame;
    private int attackCounter;
    public override void ExitState()
    {
        
    }

    public override  BossStateMachine.BossState RunState(int energy, out int energyOut)
    {
        if (attackCounter >= attackFrame)
        {
            attackCounter = 0;
            //TODO do damage
            energyOut = energy - energyCost;
            return NormalNextState;
        }
        else attackCounter++;
        energyOut = energy;
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
