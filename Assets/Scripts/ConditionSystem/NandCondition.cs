using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Nand Condition", menuName = "VIA2.0/Condition/Nand Condition", order = 0)]
public class NandCondition : Condition
{
    [SerializeField]
    private List<string> conditionTopics;
    public override bool IsPass()
    {
        for (int i = 0; i < conditionTopics.Count; i++)
        {
            if (!ConditionSystem.GetCondition(conditionTopics[i]))
            {
                return true;
            }
        }
        return false;
    }
}
