using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Not Condition", menuName = "VIA2.0/Condition/Not Condition", order = 0)]
public class NotConditon : Condition
{
    [SerializeField]
    private string conditionTopic;

    public string ConditionTopic { get => conditionTopic; set => conditionTopic = value; }

    public override bool IsPass()
    {
        if (ConditionSystem.GetCondition(conditionTopic)) return false;
        return true;
    }
}
