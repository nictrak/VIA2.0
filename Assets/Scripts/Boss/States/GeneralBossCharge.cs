using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBossCharge : BossStateBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private bool isKnock;
    [SerializeField]
    private float knockVelocity;
    [SerializeField]
    private int knockFrame;
    
    [SerializeField]
    private float velocity;
    [SerializeField]
    private BossCorner[] dashCorners;

    [SerializeField]
    private MonsterRange innerRange;

    private Vector2 targetPosition;
    private Rigidbody2D rgbody;
    private float minDistance;
    
    public override void ExitState()
    {
        
    }

    public override BossStateMachine.BossState RunState(int energy, out int energyOut)
    {
        if (innerRange.IsHitPlayer)
        {
            //Damage player
            if (innerRange.IsHitPlayer)
            {
                innerRange.TargetGameObject.GetComponent<Health>().TakeDamage(damage);
                if (isKnock)
                {
                    innerRange.TargetGameObject.GetComponent<PlayerKnockController>().StartKnock(transform.position, knockVelocity, knockFrame);
                }
            }
            Debug.Log("Hit By Boss Charge!");
        } else if (rgbody.position == targetPosition)
        {
            energyOut = energy - energyCost;
            return NormalNextState;
        }

        //Move
        if(targetPosition != null)
        {
            Move(Vector2.MoveTowards(rgbody.position, targetPosition, velocity * Time.deltaTime));
        }

        energyOut = energy;
        return currentState;
    }

    private void Move(Vector2 moveVector)
    {
        rgbody.MovePosition(moveVector);
    }

    public override void StartState()
    {
        minDistance = 0f;

        for (int i=dashCorners.Length - 1; i > -1; i--)
        {
            if(!dashCorners[i].IsCurrentCorner && dashCorners[i].PlayerDistance < minDistance)
            {
                targetPosition = dashCorners[i].GetPosition;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponentInParent<Rigidbody2D>();
    }

}
