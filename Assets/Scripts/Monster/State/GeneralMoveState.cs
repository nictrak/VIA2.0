using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMoveState : MonsterStateBehaviour
{
    [SerializeField]
    [Range(4.0F, 15.0F)]
    private float velocity;

    Vector2 targetPosition;
    private Rigidbody2D rgbody;
    private MonsterStateMachine monsterStateMachine;

    public override void ExitState()
    {
        rgbody.bodyType = RigidbodyType2D.Dynamic;
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if(rgbody.position == targetPosition)
        {
            return NormalNextState;
        } else if (targetPosition != null)
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
        targetPosition = monsterStateMachine.targetPosition;
        rgbody.bodyType = RigidbodyType2D.Kinematic;
    }

    void Start()
    {
        rgbody = GetComponentInParent<Rigidbody2D>();
        monsterStateMachine = GetComponentInParent<MonsterStateMachine>();
    }
}
