using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowCraftingWindow : MonoBehaviour
{
    private static Color normalColor = Color.white;
    private static Color disableColor = Color.clear;

    [SerializeField]
    private Image resultBorder;

    [SerializeField]
    private Image resultImage;

    [Header("Refferences")]
    [SerializeField]
    private MaterialUIController materialUIPrefab;

    [SerializeField]
    private RectTransform materialUIParent;

    [SerializeField]
    private List<MaterialUIController> materialUIs;

    [SerializeField]
    private WindowCraftingRecipe _craftingRecipe;

    public WindowCraftingRecipe CraftingRecipe {
        get { return _craftingRecipe; }
        set { SetMaterialsList(value); }
    }

    private Inventory inventory;

    public void Craft(){
        _craftingRecipe.Craft(inventory);
    }

    private void SetMaterialsList(WindowCraftingRecipe newCraftingRecipe){

        if(newCraftingRecipe == null){
            for (int i = 0; i < materialUIs.Count; i++){
                materialUIs[i].SetNull();
            }
            resultImage.color = disableColor;
            resultBorder.color = disableColor;
            gameObject.SetActive(false);
            return;
        }

        _craftingRecipe = newCraftingRecipe;

        resultImage.sprite = _craftingRecipe.Result.Item.Icon;
        resultImage.color = normalColor;
        resultBorder.color = normalColor;

        for (int i = 0; i < _craftingRecipe.Materials.Count; i++){
            
            if(materialUIs.Count == i) {
                materialUIs.Add(Instantiate(materialUIPrefab, materialUIParent, false));
            }
      
            materialUIs[i].Inventory = inventory;
            materialUIs[i].Material = _craftingRecipe.Materials[i];

        }

        for (int i = _craftingRecipe.Materials.Count; i < materialUIs.Count; i++){
            materialUIs[i].SetNull();
        }

        gameObject.SetActive(true);

    }

    private void OnValidate() {
        if(inventory == null)
        {
            Inventory[] result = Resources.FindObjectsOfTypeAll<Inventory>();
            if(result.Length > 0){
                inventory = Resources.FindObjectsOfTypeAll<Inventory>()[0];
            }
        }
        if(materialUIParent != null){
            materialUIParent.GetComponentsInChildren<MaterialUIController>(includeInactive: true, result: materialUIs);
        }
    }
}
