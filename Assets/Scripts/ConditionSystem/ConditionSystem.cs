using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionSystem : MonoBehaviour
{
    public static Dictionary<string, bool> ConditionHash;
    [SerializeField]
    private List<string> conditionTopics;

    // Start is called before the first frame update
    void Start()
    {
        if(ConditionHash == null)
        {
            ConditionHash = new Dictionary<string, bool>();
            for(int i = 0; i < conditionTopics.Count; i++)
            {
                ConditionHash.Add(conditionTopics[i], false);
            }
        }
        Object[] objs = Resources.LoadAll("Quest");
        for(int i = 0; i < objs.Length; i++)
        {
            string questName = objs[i].name;
            ConditionHash.Add("IsAssigned " + questName, false);
            ConditionHash.Add("IsCompleted " + questName, false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static bool GetCondition(string topic)
    {
        if (ConditionHash == null) return false;
        if (ConditionHash.ContainsKey(topic))
        {
            return ConditionHash[topic];
        }
        return false;
    }
    public static void SetCondition(string topic, bool value)
    {
        if (ConditionHash.ContainsKey(topic))
        {
            ConditionHash[topic] = value;
        }
        else
        {
            ConditionHash.Add(topic, value);
        }
    } 
}
