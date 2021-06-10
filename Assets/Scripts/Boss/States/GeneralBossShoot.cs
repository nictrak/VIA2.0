using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GeneralBossShoot : BossStateBehaviour
{
    [SerializeField]
    private Pattern pattern;

    [SerializeField]
    private float velocity;

    [SerializeField]
    private int delayFrame;

    [SerializeField]
    private int bulletAmount;

    [SerializeField]
    private NeedTarget spawnedPrefab;

    private int delayCounter;
    private int bulletCounter;
    private AIDestinationSetter destinationSetter;

    public override void ExitState()
    {

    }

    public override BossStateMachine.BossState RunState(int energy, out int energyOut)
    {
        if(bulletCounter >= bulletAmount){
            energyOut = energy - energyCost;
            return NormalNextState;
        }
        if (delayCounter >= delayFrame)
        {
            bulletCounter++;
            if(pattern != null){
                for(int i = 0; i < pattern.Length; i++)
                {
                    NeedTarget spawned = Instantiate(spawnedPrefab);
                    Vector2 targetPoint = (Vector2)destinationSetter.target.transform.position + pattern.GetPositionByIndex(i);
                    spawned.SetTarget(transform.position, targetPoint, velocity);
                }
                delayCounter = 0;
            } else {
                delayCounter = 0;
                NeedTarget spawned = Instantiate(spawnedPrefab);
                spawned.SetTarget(transform.position, destinationSetter.target.transform.position, velocity);
            }
        }
        else delayCounter++;
        energyOut = energy;
        return currentState;
    }

    public override void StartState()
    {
        delayCounter = 0;
        bulletCounter = 0;
        destinationSetter = GetComponentInParent<AIDestinationSetter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
