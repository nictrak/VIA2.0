using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum monsterType {
        Enemy,
        Friendly,
        Aggressive,
}

public class MonsterAttributes : MonoBehaviour
{
    public monsterType monsterType = monsterType.Enemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
