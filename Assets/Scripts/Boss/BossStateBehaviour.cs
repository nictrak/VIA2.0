using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossStateBehaviour : MonoBehaviour
{    
    [SerializeField]
    protected BossStateMachine.BossState currentState;
    public BossStateMachine.BossState NormalNextState;
    public BossStateMachine.BossState StateEnum {
        get { return currentState; }
    }

    [SerializeField]
    protected int energyCost;

    public int EnergyCost {
        get { return energyCost; }
    }
    
    public abstract void StartState();
    public abstract void ExitState();
    public abstract BossStateMachine.BossState RunState(int energy, out int energyOut);
}
