using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutSlot : ItemSlot
{

    public override bool CanReceiveItem(Item item)
    {
        if (item == null)
            return true;

        CraftingMaterialItem craftingMaterialItem = item as CraftingMaterialItem;
        return craftingMaterialItem != null;
    }
}
