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

    private int currentQuestCount;
    private Vector2 startPosition;
    private Vector2 accumulatePosition;
    // Start is called before the first frame update
    void Start()
    {
        currentQuestCount = 0;
        startPosition = new Vector2(0, -unitHeight / 2);
        accumulatePosition = new Vector2(0, -unitHeight);
    }

    // Update is called once per frame
    void Update()
    {
        while(currentQuestCount < QuestSystem.GetQuestsCount())
        {
            RectTransform spawned = Instantiate(questUnitPrefab);
            spawned.parent = transform;
            spawned.anchoredPosition = startPosition + (accumulatePosition * currentQuestCount);
            currentQuestCount++;
        }
    }
}
