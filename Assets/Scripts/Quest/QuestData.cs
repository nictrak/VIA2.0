using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "VIA2.0/Quest/New Quest", order = 0)]
public class QuestData : ScriptableObject
{
    [SerializeField]
    private int initialProgress;
    [SerializeField]
    private int goalProgress;
    [SerializeField]
    private string triggerMessage;
    [SerializeField]
    private List<string> MakeTrueAfterComplete;
    [SerializeField]
    private List<string> MakeFalseAfterComplete;
    [SerializeField]
    private string description;

    public int InitialProgress { get => initialProgress; set => initialProgress = value; }
    public int GoalProgress { get => goalProgress; set => goalProgress = value; }
    public List<string> MakeTrueAfterComplete1 { get => MakeTrueAfterComplete; set => MakeTrueAfterComplete = value; }
    public List<string> MakeFalseAfterComplete1 { get => MakeFalseAfterComplete; set => MakeFalseAfterComplete = value; }
    public string TriggerMessage { get => triggerMessage; set => triggerMessage = value; }
    public string Description { get => description; set => description = value; }
}
