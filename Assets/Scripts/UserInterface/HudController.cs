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
    private KeyCode inventoryKey;
    [SerializeField]
    private GameObject questsPanel;
    [SerializeField]
    private GameObject questPanel;
    [SerializeField]
    private KeyCode questKey;

    private bool canToggle;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
        shopPanel.SetActive(false);
        canToggle = true;
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
