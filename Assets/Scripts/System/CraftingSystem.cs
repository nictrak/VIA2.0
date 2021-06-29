using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public static Dictionary<(string, string), GameObject> CraftingHash;
    [SerializeField]
    private List<CraftingRecipe> craftingRecipes;
    // Start is called before the first frame update
    void Start()
    {
        CraftingHash = new Dictionary<(string, string), GameObject>();
        for(int i = 0; i < craftingRecipes.Count; i++)
        {
            CraftingHash.Add((craftingRecipes[i].material1, craftingRecipes[i].material2), craftingRecipes[i].resultPrefab);
            CraftingHash.Add((craftingRecipes[i].material2, craftingRecipes[i].material1), craftingRecipes[i].resultPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
