using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificItemSlot<T> : ItemSlot
{
    public override bool CanReceiveItem(Item item)
    {
        if (item == null)
            return true;

        return checkItem(item);
    }

    protected virtual bool checkItem(Item item){
        return item is T;
    }
    
}
