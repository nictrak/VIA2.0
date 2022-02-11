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
    private Image ImageLeft;
    [SerializeField]
    private Image ImageRight;

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

    public void SetImage(Dialogue dialogue)
    {
            // Load Profile-image from testUIDialog folder
            Object [] sprites;
            Object [] spritesDefault;
            spritesDefault = Resources.LoadAll ("DEFAULTUI");
            sprites = Resources.LoadAll (dialogue.TalkerName);
            // Use dialog-properties-to Create-Image Canvas
            if (sprites.Length > 0){
                SetImageSite(dialogue,sprites);
            } else{
                
                Debug.Log("FindAssets: other DEFAULTUI");
                Debug.Log("Fail Dialog-Talker"+dialogue.TalkerName);
                Debug.Log("Fail Dialog-Content"+dialogue.DialogueContent);
                Debug.Log("Fail Dialog-Content long"+spritesDefault.Length);
                SetImageSite(dialogue,spritesDefault);
            }
    }

    private void SetImageSite(Dialogue dialogue, Object [] sprites){
        if (dialogue.IsDisplayIconLeft){
            ImageLeft.enabled = dialogue.IsDisplayIconLeft;
            ImageRight.enabled = !dialogue.IsDisplayIconLeft;
            ImageLeft.sprite = (Sprite)sprites [1];
        } else{
            ImageLeft.enabled = dialogue.IsDisplayIconLeft;
            ImageRight.enabled = !dialogue.IsDisplayIconLeft;
            ImageRight.sprite = (Sprite)sprites [1];
        }
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
            SetImage(dialogue);
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
