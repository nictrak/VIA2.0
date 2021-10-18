using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Crafting Core", menuName = "VIA2.0/Crafting Core", order = 0)]
public class CraftingCore : ScriptableObject
{
    [SerializeField]
    private List<Item> costItems;
    [SerializeField]
    private List<int> costNumbers;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private CraftingMaterialItem summonedCraftingMaterial;

    public Sprite Icon { get => icon; set => icon = value; }
    public CraftingMaterialItem SummonedCraftingMaterial { get => summonedCraftingMaterial; set => summonedCraftingMaterial = value; }
}
