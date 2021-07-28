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

    private bool canInventoryToggle;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
        shopPanel.SetActive(false);
        canInventoryToggle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inventoryKey) && canInventoryToggle)
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }    
    }
    public void OpenShop()
    {
        inventoryPanel.SetActive(true);
        shopPanel.SetActive(true);
        canInventoryToggle = false;
    }
    public void CloseShop()
    {
        inventoryPanel.SetActive(false);
        shopPanel.SetActive(false);
        canInventoryToggle = true;
    }

}
