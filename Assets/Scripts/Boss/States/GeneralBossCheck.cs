using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBossCheck : BossStateBehaviour
{

    [SerializeField]
    private MonsterRange innerRange;

    [SerializeField]
    private MonsterRange outerRange;

    [SerializeField]
    private BossStateMachine.BossState outerRangeNextState;

    public override void ExitState()
    {
        
    }

    public override BossStateMachine.BossState RunState(int energy, out int energyOut)
    {
        if (innerRange.IsHitPlayer)
        {
            energyOut = energy - energyCost;
            return NormalNextState;
        } else if (outerRange.IsHitPlayer)
        {
            energyOut = energy - energyCost;
            return outerRangeNextState;
        }
        energyOut = energy;
        return currentState;
    }

    public override void StartState()
    {
    
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
