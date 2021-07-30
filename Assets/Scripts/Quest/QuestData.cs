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
    private List<string> makeTrueAfterComplete;
    [SerializeField]
    private List<string> makeFalseAfterComplete;
    [SerializeField]
    [Multiline]
    private string description;

    public int InitialProgress { get => initialProgress; set => initialProgress = value; }
    public int GoalProgress { get => goalProgress; set => goalProgress = value; }
    public string TriggerMessage { get => triggerMessage; set => triggerMessage = value; }
    public string Description { get => description; set => description = value; }
    public List<string> MakeTrueAfterComplete { get => makeTrueAfterComplete; set => makeTrueAfterComplete = value; }
    public List<string> MakeFalseAfterComplete { get => makeFalseAfterComplete; set => makeFalseAfterComplete = value; }
}
