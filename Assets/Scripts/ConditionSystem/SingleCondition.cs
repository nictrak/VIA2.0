using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCondition : Condition
{
    [SerializeField]
    private string conditionTopic;
    public override bool IsPass()
    {
        return ConditionSystem.GetCondition(conditionTopic);
    }
}
