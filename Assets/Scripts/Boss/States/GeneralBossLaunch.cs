using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBossLaunch : BossStateBehaviour
{

    [SerializeField]
    private List<Vector2> positions;

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
            if(positions.Count != 0){
                for(int i = 0; i < positions.Count; i++)
                {
                    NeedTarget spawned = Instantiate(spawnedPrefab);
                    spawned.SetTarget(transform.position, positions[i], velocity);
                }
                delayCounter = 0;
            } else {
                energyOut = energy - energyCost;
                return NormalNextState;
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
