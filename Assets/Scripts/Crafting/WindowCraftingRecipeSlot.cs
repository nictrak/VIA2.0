using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowCraftingRecipeSlot : MonoBehaviour
{

    private static Color normalColor = Color.white;
    private static Color disableColor = Color.clear;

    [SerializeField]
    private Image image;
    [SerializeField]
    private Image bg;
    private WindowCraftingRecipe _recipe;

    public WindowCraftingRecipe Recipe {
        get { return _recipe; }

        set {

            _recipe = value;
            if(_recipe == null){
                image.color = disableColor;
                bg.color = disableColor;
            } else {
                image.sprite = _recipe.Result.Item.Icon;
                image.color = normalColor;
                bg.color = normalColor;
            }

        }
    }

    private void OnValidate() {
        if (image == null) {
            image = transform.GetChild(0).GetComponent<Image>();
        }
        if (bg == null) {
            bg = GetComponent<Image>();
        }
    }

}
