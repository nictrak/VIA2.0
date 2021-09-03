using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnState : MonsterStateBehaviour
{
    [SerializeField]
    private GameObject spawnedPrefab;
    [SerializeField]
    private int delayFrame;

    private int counter;
    private TargetBuffer targetBuffer;
    public override void ExitState()
    {
        
    }

    public override MonsterStateMachine.MonsterState RunState()
    {
        if(counter >= delayFrame)
        {
            GameObject spawned = Instantiate(spawnedPrefab);
            spawned.transform.position = targetBuffer.TargetPosition;
            targetBuffer.IsAim = false;
            counter = 0;
            return NormalNextState;
        }
        counter++;
        return currentState;
    }

    public override void StartState()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        targetBuffer = GetComponentInParent<TargetBuffer>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
