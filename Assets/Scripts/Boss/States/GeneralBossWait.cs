using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBossWait : BossStateBehaviour
{

    [SerializeField]
    private int delayFrame;

    [SerializeField]
    private int energyRecharge;
    private int delayCounter;

    public override void ExitState()
    {

    }

    public override BossStateMachine.BossState RunState(int energy, out int energyOut)
    {
        if (delayCounter >= delayFrame)
        {
            delayCounter = 0;
            if(energy <= 2){
                energyOut = energyRecharge;
            } else {
                energyOut = energy - energyCost;
            }
            return NormalNextState;
        }
        else delayCounter++;
        if(energy <= 2){
                energyOut = energyRecharge;
        } else {
            energyOut = energy - energyCost;
        }
        return currentState;
    }

    public override void StartState()
    {
        delayCounter = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
