using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftingCoreSlot:MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private CraftingCore craftingCore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSprite(CraftingCore newCraftingCore)
    {
        image.sprite = newCraftingCore.Icon;
    }
}
