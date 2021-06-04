using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel;
    [SerializeField]
    private KeyCode inventoryKey;

    private bool isInventoryOpen;
    // Start is called before the first frame update
    void Start()
    {
        isInventoryOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            if (isInventoryOpen)
            {
                inventoryPanel.SetActive(false);
                isInventoryOpen = false;
            }
            else
            {
                inventoryPanel.SetActive(true);
                isInventoryOpen = true;
            }
        }    
    }

}
