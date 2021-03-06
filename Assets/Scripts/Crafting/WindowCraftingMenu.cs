using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowCraftingMenu : MonoBehaviour
{

    [Header("Refferences")]
    [SerializeField]
    private WindowCraftMenuUIController recipeRowUIPrefab;
    [SerializeField]
    private RectTransform recipeRowUIParent;

    [SerializeField]
    private List<WindowCraftMenuUIController> recipeRowUIs;

    private Dictionary<ItemType, List<WindowCraftingRecipe>> seperatedList;

    [SerializeField]
    public List<WindowCraftingRecipe> craftingList;

    private void SeperateCraftingType(){
        for (int i = 0; i < craftingList.Count; i++){
            seperatedList[craftingList[i].type].Add(craftingList[i]);
        }
    }

    private void SetWindowCraftingRecipe(){
        int i = 0;
        foreach(ItemType type in System.Enum.GetValues(typeof(ItemType))){
            if(recipeRowUIs.Count == i) {
                WindowCraftMenuUIController temp = Instantiate(recipeRowUIPrefab, recipeRowUIParent, false);
                temp.recipeRowUIParent = recipeRowUIParent;
                recipeRowUIs.Add(temp);
            } else if (recipeRowUIs[i] == null) {
                WindowCraftMenuUIController temp = Instantiate(recipeRowUIPrefab, recipeRowUIParent, false);
                temp.recipeRowUIParent = recipeRowUIParent;
                recipeRowUIs[i] = temp;
            }
    
            recipeRowUIs[i].SetWindowCraftingRecipe(seperatedList[type], type);
            i++;

        }

        for (i = seperatedList.Count; i < recipeRowUIs.Count; i++){
            recipeRowUIs[i].SetNullWindowCraftingRecipe();
        }
    }
    private void OnValidate() {
        if(recipeRowUIParent != null){
            recipeRowUIParent.GetComponentsInChildren<WindowCraftMenuUIController>(includeInactive: true, result: recipeRowUIs);
            seperatedList = new Dictionary<ItemType, List<WindowCraftingRecipe>>();
            foreach(ItemType type in System.Enum.GetValues(typeof(ItemType))){
                seperatedList[type] = new List<WindowCraftingRecipe>();
            }
            SeperateCraftingType();
            SetWindowCraftingRecipe();
        }
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
