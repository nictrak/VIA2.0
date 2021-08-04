using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{
    [SerializeField]
    private Text questDescription;
    [SerializeField]
    private Text questsCount;
    private int currentQuestIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentQuestIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int count = QuestSystem.GetQuestsCount();
        if (Input.GetKeyDown(KeyCode.F1))
        {
            currentQuestIndex--;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            currentQuestIndex++;
        }
        if (currentQuestIndex >= count)
        {
            currentQuestIndex = 0;
        }else if(currentQuestIndex < 0)
        {
            currentQuestIndex = count - 1;
        }
        if (questDescription != null) questDescription.text = QuestSystem.GetQuestDescriptionFromIndex(currentQuestIndex);
        if(questsCount != null)
        {
            if (count > 0)
            {
                questsCount.text = (currentQuestIndex + 1) + "/" + QuestSystem.GetQuestsCount();
            }
            else
            {
                questsCount.text = "";
            }
        }
    }
}
