using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralChargeState : MonsterStateBehaviour
{

    [SerializeField]
    private MonsterStateMachine.MonsterState outerRangeNextState;
    
    [SerializeField]
    private AggressiveTriggerRange innerRange;
    [SerializeField]
    private TriggerRange outerRange;

    [SerializeField]
    private float velocity;
    [SerializeField]
    private int damage = 100;
    [SerializeField]
    [Range(4.0F, 6.0F)]
    private float knockbackRange = 5f;
    private Vector2 targetPosition;
    private Rigidbody2D rgbody;
    private TargetBuffer targetBuffer;


    private MonsterStateMachine monsterStateMachine;

    public override void ExitState()
    {
        rgbody.bodyType = RigidbodyType2D.Dynamic;
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if(!innerRange.IsSubEmpty()){
            while(!innerRange.IsSubEmpty()){
                GameObject monster = innerRange.PopSub();
                Vector2 thisToTarget = (Vector2)transform.position - targetPosition;
                Vector2 thisToMonster = (Vector2)transform.position - (Vector2)monster.transform.position;
                float angle = Vector2.SignedAngle(thisToTarget, thisToMonster);
                //Debug.Log("Angle: "+angle+" MoveVector: "+thisToMonster+" From: "+(Vector2)transform.position+" To: "+(Vector2)monster.transform.position);
                Health monsterHealth = monster.GetComponentInParent<Health>();
                Vector2 damagePosition = transform.position;
                if(Mathf.Abs(angle) < 30){
                    //damagePosition += new 
                }
                monsterHealth.TakeDamage(new DamageInput(damage), new AttackEffectInput(), new KnockbackInput(damagePosition, knockbackRange));
            }
        }
        if (!innerRange.IsEmpty())
        {
            monsterStateMachine.targetPosition = getTarget();
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
        targetPosition = getTarget();
        rgbody.bodyType = RigidbodyType2D.Kinematic;
    }

    private Vector2 getTarget(){
        Vector2 targetPosition;
        if(targetBuffer == null){
            targetPosition = GetTarget().transform.position;
        } else {
            targetPosition = targetBuffer.CancleAim();
            if ( targetPosition == (Vector2)this.transform.position ){
                targetPosition = GetTarget().transform.position;
            }
        }
        return targetPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponentInParent<Rigidbody2D>();
        monsterStateMachine = GetComponentInParent<MonsterStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
