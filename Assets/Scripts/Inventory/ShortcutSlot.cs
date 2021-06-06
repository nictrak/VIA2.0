using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutSlot : ItemSlot
{

    public override bool CanReceiveItem(Item item)
    {
        if (item == null)
            return true;

        PortionItem portionItem = item as PortionItem;
        return portionItem != null;
    }
}
