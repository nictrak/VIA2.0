using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    private Text talkerNameText;
    [SerializeField]
    private Text dialogueText;
    [SerializeField]
    private Button button1;
    [SerializeField]
    private Button button2;
    [SerializeField]
    private Button button3;
    [SerializeField]
    private Button button4;
    [SerializeField]
    private Image Image;

    private bool isShow;
    // Start is called before the first frame update
    void Start()
    {
        isShow = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetText(string talkerName, string dialogue)
    {
        talkerNameText.text = talkerName;
        dialogueText.text = dialogue;
    }
    public void SetText(Dialogue dialogue)
    {
        talkerNameText.text = dialogue.TalkerName;
        dialogueText.text = dialogue.DialogueContent;
    }

    public void SetImage(string talkerName)
    {
        // talkerNameText.text = dialogue.TalkerName;
        // dialogueText.text = dialogue.DialogueContent;
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        if(dialogue == null)
        {
            SetActivePanel(false);
            isShow = false;
        }
        else
        {
            if (!isShow)
            {
                SetActivePanel(true);
            }
            SetActiveButton(dialogue.GetChoicesString());
            SetText(dialogue);
            // "Assets\Materials\Characters\Mark inport.1"
            Object [] sprites;
            sprites = Resources.LoadAll ("testUIDialog/animal");
            Debug.Log("FindAssets");
            Debug.Log((Sprite)sprites [3]);
            Image.sprite = (Sprite)sprites [3];
        }
    }
    public void SetActivePanel(bool isActive)
    {
        dialoguePanel.SetActive(isActive);
        isShow = isActive;
    }
    public void SetActiveButton(List<string> strings)
    {
        int number = 0;
        if(strings != null)
        {
            number = strings.Count;
        }
        if (number > 0)
        {
            button1.gameObject.SetActive(true);
            button1.GetComponentInChildren<Text>().text = strings[0];
        }
        else
        {
            button1.gameObject.SetActive(false);
        }

        if (number > 1)
        {
            button2.gameObject.SetActive(true);
            button2.GetComponentInChildren<Text>().text = strings[1];
        }
        else
        {
            button2.gameObject.SetActive(false);
        }

        if (number > 2)
        {
            button3.gameObject.SetActive(true);
            button3.GetComponentInChildren<Text>().text = strings[2];
        }
        else
        {
            button3.gameObject.SetActive(false);
        }

        if (number > 3)
        {
            button4.gameObject.SetActive(true);
            button4.GetComponentInChildren<Text>().text = strings[3];
        }
        else
        {
            button4.gameObject.SetActive(false);
        }
    }
    public void SelectChoice(int param)
    {
        PlayerInteractionController interactionController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteractionController>();
        interactionController.NextDialogueSelectedChoice(param);
    }
}
