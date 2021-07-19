using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Single Condition", menuName = "VIA2.0/Condition/Single Condition", order = 0)]
public class SingleCondition : Condition
{
    [SerializeField]
    private string conditionTopic;
    public override bool IsPass()
    {
        return ConditionSystem.GetCondition(conditionTopic);
    }
}
