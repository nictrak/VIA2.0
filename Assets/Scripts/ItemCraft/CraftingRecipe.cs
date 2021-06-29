using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crafting Recipe", menuName = "VIA2.0/Crafting Recipe", order = 0)]
public class CraftingRecipe: ScriptableObject
{
    public string material1;
    public string material2;
    public GameObject resultPrefab;
}
