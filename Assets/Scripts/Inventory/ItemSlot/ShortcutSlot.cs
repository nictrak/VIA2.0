using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutSlot : SpecificItemSlot<IShortcutable>
{
    public event Action OnSlotChange;

    public bool UseItem(bool isRightClick){

        IShortcutable item = (IShortcutable)Item;
        if(item != null && item.CanUse()){
            Amount -= item.Use(isRightClick);
            return true;
        }
        return false;
        
    }

    public override Item Item {
        get { return _item; }

        set {

            _item = value;
            if(_item == null){
                image.color = disableColor;
            } else {
                image.sprite = _item.Icon;
                image.color = normalColor;
            }

            OnSlotChange?.Invoke();

        }
    }

}
