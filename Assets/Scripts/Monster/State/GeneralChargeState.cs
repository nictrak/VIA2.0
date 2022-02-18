using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralChargeState : MonsterStateBehaviour
{

    [SerializeField]
    private MonsterStateMachine.MonsterState outerRangeNextState;
    
    [SerializeField]
    private TriggerRange innerRange;
    [SerializeField]
    private TriggerRange outerRange;

    [SerializeField]
    private float velocity;

    private Vector2 targetPosition;
    private Rigidbody2D rgbody;
    private TargetBuffer targetBuffer;

    public override void ExitState()
    {

    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (!innerRange.IsEmpty())
        {
            return NormalNextState;
        } else if (rgbody.position == targetPosition)
        {
            return outerRangeNextState;
        }

        //Move
        if(targetPosition != null)
        {
            Move(Vector2.MoveTowards(rgbody.position, targetPosition, velocity * Time.deltaTime));
        }

        return currentState;
    }

    private void Move(Vector2 moveVector)
    {
        rgbody.MovePosition(moveVector);
    }

    public override void StartState()
    {
        //set Distination
        targetBuffer = GetComponentInParent<TargetBuffer>();
        if(targetBuffer == null){
            targetPosition = GetTarget().transform.position;
        } else {
            targetPosition = targetBuffer.CancleAim();
            if ( targetPosition == (Vector2)this.transform.position ){
                targetPosition = GetTarget().transform.position;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
