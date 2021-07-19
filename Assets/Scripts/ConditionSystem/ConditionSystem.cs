using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionSystem : MonoBehaviour
{
    public static Dictionary<string, bool> ConditionHash;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
