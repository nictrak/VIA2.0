using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
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
    private KeyCode questKey;
    [SerializeField]
    private GameObject windowCraftPanel;
    [SerializeField]
    private KeyCode windowCraftKey;

    private bool canToggle;
    public static bool IsUsed;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
        shopPanel.SetActive(false);
        windowCraftPanel.SetActive(false);
        canToggle = true;
        IsUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inventoryKey) && canToggle)
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
        if (Input.GetKeyDown(questKey) && canToggle)
        {
            questPanel.SetActive(!questPanel.activeSelf);
            questsPanel.SetActive(!questsPanel.activeSelf);
        }
        if (Input.GetKeyDown(craftingCoreKey) && canToggle)
        {
            craftingCorePanel.SetActive(!craftingCorePanel.activeSelf);
            shortcutPanel.SetActive(!shortcutPanel.activeSelf);
            TimeSystem timeSystem = Resources.FindObjectsOfTypeAll<TimeSystem>()[0];
            if (craftingCorePanel.activeSelf)
            {
                timeSystem.DoSlowMotion();
            }
            else
            {
                timeSystem.DoStandardTime();
            }
        }
        if (Input.GetKeyDown(windowCraftKey) && canToggle)
        {
            windowCraftPanel.SetActive(!windowCraftPanel.activeSelf);
        }
        if (inventoryPanel.activeSelf || craftingCorePanel.activeSelf || windowCraftPanel.activeSelf)
        {
            IsUsed = true;
        }
        else
        {
            IsUsed = false;
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

}
