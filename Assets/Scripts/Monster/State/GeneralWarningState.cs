using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralWarningState : MonsterStateBehaviour
{
    [SerializeField]
    private MonsterStateMachine.MonsterState outerRangeNextState;

    [SerializeField]
    private MonsterRange innerRange;

    [SerializeField]
    private float delayTime;

    private float timer;

    public override void ExitState()
    {
        
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (innerRange.IsHitPlayer)
        {
            if(timer == 0f)
            {
                return NormalNextState;
            }
            timer -= 1f;
            return currentState;
        }
        return outerRangeNextState;
    }

    public override void StartState()
    {
        timer = delayTime;
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
