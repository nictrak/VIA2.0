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

    private Vector2 different;
    private Vector2 startPosition;
    private Rigidbody2D rgbody;

    private float percentage;


    public override void ExitState()
    {

    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (innerRange.IsHitPlayer)
        {
            return NormalNextState;
        } else if (percentage == 1f)
        {
            return outerRangeNextState;
        }

        //Move
        if(different != null)
        {
            percentage += velocity;
            if(percentage > 1f) percentage = 1f;
            Move( ( different )*percentage );
        }

        return currentState;
    }

    private void Move(Vector2 moveVector)
    {
        rgbody.MovePosition(startPosition - moveVector);
    }

    public override void StartState()
    {
        //set Distination
        percentage = 0f;
        startPosition = rgbody.position;
        different =  rgbody.position - outerRange.TargetPosition;
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
