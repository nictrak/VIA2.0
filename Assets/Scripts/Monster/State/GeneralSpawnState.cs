using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GeneralSpawnState : MonsterStateBehaviour
{
    [SerializeField]
    private NeedTarget spawnedPrefab;
    [SerializeField]
    private int delayFrame;
    [SerializeField]
    private float velocity;
    [SerializeField]
    private MonsterStateMachine.MonsterState outerRangeNextState;
    [SerializeField]
    private TriggerRange outerRange;
    [SerializeField]
    private TriggerRange innerRange;
    [SerializeField]
    private float randomRadius;
    
    [SerializeField]
    private float magicBulletPosX;

        [SerializeField]
    private float magicBulletPosY;

    private int delayCounter;

    public override void ExitState()
    {
        
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if (delayCounter >= delayFrame)
        {
            delayCounter = 0;
            NeedTarget spawned = Instantiate(spawnedPrefab);
            spawned.SetTarget(transform.position, GetTarget().transform.position + RandomVector(), velocity);
        }
        else delayCounter++;
        if (!innerRange.IsEmpty())
        {
            return NormalNextState;
        }
        else
        {
            if (outerRange != null)
            {
                if (outerRange.IsEmpty())
                {
                    return outerRangeNextState;
                }
            }
        }
        return currentState;
    }

    public override void StartState()
    {
        
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
    private Vector3 RandomVector()
    {
        return new Vector3(Random.Range(-randomRadius, randomRadius), Random.Range(-randomRadius, randomRadius), 0);
    }
}
