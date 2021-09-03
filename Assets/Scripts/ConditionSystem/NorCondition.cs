using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Nor Condition", menuName = "VIA2.0/Condition/Nor Condition", order = 0)]
public class NorCondition : Condition
{
    [SerializeField]
    private List<string> conditionTopics;
    public override bool IsPass()
    {
        for (int i = 0; i < conditionTopics.Count; i++)
        {
            if (ConditionSystem.GetCondition(conditionTopics[i]))
            {
                return false;
            }
        }
        return true;
    }
}
