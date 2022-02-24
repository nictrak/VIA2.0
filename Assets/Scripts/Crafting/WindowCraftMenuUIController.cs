using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowCraftMenuUIController : MonoBehaviour
{
    // Start is called before the first frame update
    private static Color normalColor = Color.white;
    private static Color disableColor = Color.clear;

    [Header("Refferences")]
    [SerializeField]
    private WindowCraftingRecipeSlot recipeSlotUIPrefab;
    [SerializeField]
    private RectTransform recipeSlotUIParent;

    [SerializeField]
    private List<WindowCraftingRecipeSlot> recipeSlotUIs;

    [SerializeField]
    private Text type;

    public void SetWindowCraftingRecipe(List<WindowCraftingRecipe> recipesList, ItemType typeName){

        type.text = System.Enum.GetName(typeof(ItemType), typeName);

        if(recipesList == null){
            for (int i = 0; i < recipeSlotUIs.Count; i++){
                recipeSlotUIs[i].Recipe = null;
            }
            return;
        }

        for (int i = 0; i < recipesList.Count; i++){
            if(recipeSlotUIs.Count == i) {
                WindowCraftingRecipeSlot temp = Instantiate(recipeSlotUIPrefab, recipeSlotUIParent, false);
                recipeSlotUIs.Add(temp);

            } else if (recipeSlotUIs[i] == null) {
                recipeSlotUIs[i] = Instantiate(recipeSlotUIPrefab, recipeSlotUIParent, false);
            } 
            recipeSlotUIs[i].Recipe = recipesList[i];
        }

        for (int i = recipesList.Count; i < recipeSlotUIs.Count; i++){
            recipeSlotUIs[i].Recipe = null;
        }

        gameObject.SetActive(true);

    }

    public void SetNullWindowCraftingRecipe(){
        type.text = "";
        for (int i = 0; i < recipeSlotUIs.Count; i++){
            recipeSlotUIs[i].Recipe = null;
        }
        gameObject.SetActive(false);
        return;
    }

    private void OnValidate() {
        if(recipeSlotUIParent != null){
            recipeSlotUIParent.GetComponentsInChildren<WindowCraftingRecipeSlot>(includeInactive: true, result: recipeSlotUIs);
        }
    }

}
