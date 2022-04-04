using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public enum HUD_STATE
    {
        IDLE,
        INVENTORY,
        SHOP,
        CRAFTINGCORE,
        CRAFTING,
        QUESTS
    }

    [SerializeField]
    private GameObject inventoryPanel;
    [SerializeField]
    private GameObject shopPanel;
    [SerializeField]
    private GameObject craftingCorePanel;
    [SerializeField]
    private GameObject shortcutPanel;
    [SerializeField]
    private KeyCode inventoryKey;
    [SerializeField]
    private KeyCode craftingCoreKey;
    [SerializeField]
    private GameObject questsPanel;
    [SerializeField]
    private GameObject questPanel;
    [SerializeField]
    private GameObject sideTab;
    [SerializeField]
    private KeyCode questsKey;
    [SerializeField]
    private GameObject windowCraftPanel;
    [SerializeField]
    private KeyCode windowCraftKey;

    private bool canToggle;
    public static bool IsUsed;
    public static HUD_STATE CurrentState;

    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
        shopPanel.SetActive(false);
        windowCraftPanel.SetActive(false);
        questsPanel.SetActive(false);
        canToggle = true;
        IsUsed = false;
        CurrentState = HUD_STATE.IDLE;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            if (CurrentState == HUD_STATE.IDLE)
            {
                inventoryPanel.SetActive(true);
                sideTab.SetActive(true);
                CurrentState = HUD_STATE.INVENTORY;
            }
            else if (CurrentState == HUD_STATE.INVENTORY)
            {
                inventoryPanel.SetActive(false);
                sideTab.SetActive(false);
                CurrentState = HUD_STATE.IDLE;
            }
        }
        if (Input.GetKeyDown(questsKey))
        {
            if (CurrentState == HUD_STATE.IDLE)
            {
                questPanel.SetActive(false);
                questsPanel.SetActive(true);
                sideTab.SetActive(true);
                CurrentState = HUD_STATE.QUESTS;
            }
            else if (CurrentState == HUD_STATE.QUESTS)
            {
                questPanel.SetActive(true);
                questsPanel.SetActive(false);
                sideTab.SetActive(false);
                CurrentState = HUD_STATE.IDLE;
            }
        }
        if (Input.GetKeyDown(craftingCoreKey))
        {
            if (CurrentState == HUD_STATE.IDLE)
            {
                craftingCorePanel.SetActive(true);
                shortcutPanel.SetActive(false);
                TimeSystem timeSystem = Resources.FindObjectsOfTypeAll<TimeSystem>()[0];
                timeSystem.DoSlowMotion();
                CurrentState = HUD_STATE.CRAFTINGCORE;
            }
            else if(CurrentState == HUD_STATE.CRAFTINGCORE)
            {
                craftingCorePanel.SetActive(false);
                shortcutPanel.SetActive(true);
                TimeSystem timeSystem = Resources.FindObjectsOfTypeAll<TimeSystem>()[0];
                timeSystem.DoStandardTime();
                CurrentState = HUD_STATE.IDLE;
            }
        }
        if (Input.GetKeyDown(windowCraftKey))
        {
            if (CurrentState == HUD_STATE.IDLE)
            {
                windowCraftPanel.SetActive(true);
                CurrentState = HUD_STATE.CRAFTING;
            }
            else if (CurrentState == HUD_STATE.CRAFTING)
            {
                windowCraftPanel.SetActive(false);
                CurrentState = HUD_STATE.IDLE;
            }
        }
        if (inventoryPanel.activeSelf || craftingCorePanel.activeSelf || windowCraftPanel.activeSelf || questsPanel.activeSelf)
        {
            IsUsed = true;
        }
        else
        {
            IsUsed = false;
        }

        if(CurrentState != HUD_STATE.IDLE){
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void OpenShop()
    {
        inventoryPanel.SetActive(true);
        shopPanel.SetActive(true);
        canToggle = false;
    }
    public void CloseShop()
    {
        inventoryPanel.SetActive(false);
        shopPanel.SetActive(false);
        canToggle = true;
    }
    public void GoToIdle()
    {
        inventoryPanel.SetActive(false);
        shopPanel.SetActive(false);
        windowCraftPanel.SetActive(false);
        questsPanel.SetActive(false);
        questPanel.SetActive(true);
        canToggle = true;
        IsUsed = false;
        CurrentState = HUD_STATE.IDLE;
    }
    public void GoToInventory()
    {
        GoToIdle();
        inventoryPanel.SetActive(true);
        CurrentState = HUD_STATE.INVENTORY;
    }
    public void GoToQuests()
    {
        GoToIdle();
        questPanel.SetActive(false);
        questsPanel.SetActive(true);
        CurrentState = HUD_STATE.QUESTS;
    }
}
