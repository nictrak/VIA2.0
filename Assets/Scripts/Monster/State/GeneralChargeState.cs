using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralChargeState : MonsterStateBehaviour
{

    [SerializeField]
    private MonsterStateMachine.MonsterState outerRangeNextState;
    
    [SerializeField]
    private MonsterRange innerRange;
    [SerializeField]
    private MonsterRange outerRange;

    [SerializeField]
    private float velocity;

    private Vector2 targetPosition;
    private Rigidbody2D rgbody;

    public override void ExitState()
    {

    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (innerRange.IsHitPlayer)
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
        targetPosition = outerRange.TargetPosition;
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
