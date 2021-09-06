using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingCoreHUD : MonoBehaviour
{
    [SerializeField]
    private List<CraftingCore> craftingCores;
    [SerializeField]
    private int selectedCraftingCoreSlotsIndex;
    [SerializeField]
    private List<CraftingCoreSlot> craftingCoreSlots;

    private int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        UpdateAllSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private CraftingCore GetCycleCraftingCores(int index)
    {
        if (index < 0)
        {
            return craftingCores[index + craftingCores.Count];
        }
        else if (index > craftingCores.Count)
        {
            return craftingCores[index % craftingCores.Count];
        }
        else
        {
            return craftingCores[index];
        }
    }
    private void NextCycleCraftingCoreIndex()
    {
        int nextIndex = currentIndex + 1;
        if(nextIndex >= craftingCores.Count)
        {
            nextIndex = nextIndex - craftingCores.Count;
        }
        currentIndex = nextIndex;
    }
    private void BackCycleCraftingCoreIndex()
    {
        int nextIndex = currentIndex - 1;
        if (nextIndex < 0)
        {
            nextIndex = nextIndex + craftingCores.Count;
        }
        currentIndex = nextIndex;
    }
    private void UpdateAllSprite()
    {
        for (int i = 0; i < craftingCoreSlots.Count; i++)
        {
            craftingCoreSlots[i].UpdateSprite(craftingCores[currentIndex + i - selectedCraftingCoreSlotsIndex]);
        }
    }
}
