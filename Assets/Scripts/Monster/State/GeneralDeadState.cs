using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralDeadState : MonsterStateBehaviour
{
    [SerializeField]
    private int delayFrame;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Collider2D blocker;
    [SerializeField]
    private Rigidbody2D parentRb;
    [SerializeField]
    private Collider2D parentCollider;

    private int delayCounter;
    public override void ExitState()
    {
        
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (delayCounter >= delayFrame)
        {
            delayCounter = 0;
            Destroy(target);
            return NormalNextState;
        }
        else delayCounter++;
        return currentState;
    }

    public override void StartState()
    {
        TargetBuffer targetBuffer = this.transform.root.gameObject.GetComponent<TargetBuffer>();
        if (targetBuffer != null) targetBuffer.CancleAim();
        if (parentRb != null) parentRb.constraints = RigidbodyConstraints2D.FreezePosition;
        if (parentCollider != null) parentCollider.isTrigger = true;
        if (blocker != null) blocker.isTrigger = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        delayCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
