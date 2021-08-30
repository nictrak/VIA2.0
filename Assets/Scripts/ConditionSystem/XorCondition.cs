using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Xor Condition", menuName = "VIA2.0/Condition/Xor Condition", order = 0)]
public class XorCondition : Condition
{
    [SerializeField]
    private List<string> conditionTopics;
    public override bool IsPass()
    {
        int count = 0;
        for (int i = 0; i < conditionTopics.Count; i++)
        {
            if (ConditionSystem.GetCondition(conditionTopics[i]))
            {
                count++;
            }
        }
        if (count % 2 == 0) return false;
        return true;
    }
}
