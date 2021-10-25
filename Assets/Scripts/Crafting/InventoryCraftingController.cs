using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCraftingController : MonoBehaviour
{
    [SerializeField]
    private WindowCraftingMenu menu;

    [SerializeField]
    private WindowCraftingWindow craftingWindow;

    public void openWindow(WindowCraftingRecipe recipe){
        craftingWindow.CraftingRecipe = recipe;
    }

    public void closeWindow(){
        craftingWindow.CraftingRecipe = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
