using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GeneralAimState : MonsterStateBehaviour
{
    [SerializeField]
    private GameObject aimPrefab;
    
    [SerializeField]
    private int aimingTime;
    [SerializeField]
    private int waitingTime;
    private int waitingCounter;
    private bool isAimed;
    private TargetBuffer targetBuffer;
    public override void ExitState()
    {

    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if(waitingCounter >= aimingTime && !isAimed) {
            Vector2 position = GetTarget().transform.position;
            targetBuffer.Aim(aimPrefab, position);
            isAimed = true;
        }

        if (waitingCounter >= waitingTime)
        {
            return NormalNextState;
        }
        else waitingCounter++;

        return currentState;
    }

    public override void StartState()
    {
        waitingCounter = 0;
        isAimed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        targetBuffer = this.transform.root.gameObject.GetComponent<TargetBuffer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
