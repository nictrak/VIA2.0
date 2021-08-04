using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Or Condition", menuName = "VIA2.0/Condition/Or Condition", order = 0)]
public class OrCondition : Condition
{
    [SerializeField]
    private List<string> conditionTopics;
    public override bool IsPass()
    {
        for(int i = 0; i < conditionTopics.Count; i++)
        {
            if (ConditionSystem.GetCondition(conditionTopics[i]))
            {
                return true;
            }
        }
        return false;
    }
}
