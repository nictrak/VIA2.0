using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
    [SerializeField]
    private QuestData nextQuest;

    public int InitialProgress { get => initialProgress; set => initialProgress = value; }
    public int GoalProgress { get => goalProgress; set => goalProgress = value; }
    public string TriggerMessage { get => triggerMessage; set => triggerMessage = value; }
    public string Description { get => description; set => description = value; }
    public List<string> MakeTrueAfterComplete { get => makeTrueAfterComplete; set => makeTrueAfterComplete = value; }
    public List<string> MakeFalseAfterComplete { get => makeFalseAfterComplete; set => makeFalseAfterComplete = value; }
    public QuestData NextQuest { get => nextQuest; set => nextQuest = value; }

    #if UNITY_EDITOR
    private void OnValidate()
    {
        if(AssetDatabase.LoadAssetAtPath("Assets/Resources/Condition/IsAssigned " + name + ".asset", typeof(Condition)) == null)
        {
            SingleCondition asset = ScriptableObject.CreateInstance<SingleCondition>();
            asset.ConditionTopic = "IsAssigned " + name;
            AssetDatabase.CreateAsset(asset, "Assets/Resources/Condition/IsAssigned " + name + ".asset");
        }

        if (AssetDatabase.LoadAssetAtPath("Assets/Resources/Condition/IsCompleted " + name + ".asset", typeof(Condition)) == null)
        {
            SingleCondition asset2 = ScriptableObject.CreateInstance<SingleCondition>();
            asset2.ConditionTopic = "IsCompleted " + name;
            AssetDatabase.CreateAsset(asset2, "Assets/Resources/Condition/IsCompleted " + name + ".asset");
        }

        AssetDatabase.Refresh();
    }
    #endif
}
