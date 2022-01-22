using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestsPanel : MonoBehaviour
{
    [SerializeField]
    private RectTransform questUnitPrefab;
    [SerializeField]
    private float unitHeight;
    [SerializeField]
    private Transform contentTransform;

    private Vector2 startPosition;
    private Vector2 accumulatePosition;
    private List<RectTransform> units;
    // Start is called before the first frame update
    void Start()
    {
        units = new List<RectTransform>();
        startPosition = new Vector2(0, -unitHeight / 2);
        accumulatePosition = new Vector2(0, -unitHeight);
    }

    // Update is called once per frame
    void Update()
    {
        while(units.Count < QuestSystem.GetQuestsCount())
        {
            RectTransform spawned = Instantiate(questUnitPrefab);
            spawned.parent = contentTransform;
            spawned.anchoredPosition = startPosition + (accumulatePosition * units.Count);
            units.Add(spawned);
        }
        for(int i = 0; i < units.Count; i++)
        {
            units[i].GetComponent<QuestUnitPanel>().DescriptionText.text 
                = QuestSystem.GetQuestDescriptionFromIndex(i);
        }
    }
}
