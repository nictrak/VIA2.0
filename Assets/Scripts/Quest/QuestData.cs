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
    private Watcher watcherPrefab;
    [SerializeField]
    private List<string> MakeTrueAfterComplete;
    [SerializeField]
    private List<string> MakeFalseAfterComplete;
}
