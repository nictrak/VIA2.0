using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GeneralAggroState : MonsterStateBehaviour
{
    private AIPath aiPath;
    private bool isHit;
    public override void ExitState()
    {
        aiPath.canMove = false;
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (isHit)
        {
            return NormalNextState;
        }
        return currentState;
    }

    public override void StartState()
    {
        aiPath.canMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponentInParent<AIPath>();
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isHit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isHit = false;
        }
    }
}
