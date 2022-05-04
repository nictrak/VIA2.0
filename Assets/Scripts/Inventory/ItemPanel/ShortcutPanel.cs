using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShortcutPanel : ItemPanel<ShortcutSlot>
{
    public ShortcutSlot SelectedSlot;
    private int selectedSlotNumber;
    
    #region Override
    protected override void Start() {
        base.Start();
        SelectedSlot = ItemSlots[0];
        selectedSlotNumber = 0;
        SelectedSlot.OnSlotChange += UpdateSelectedShortcut;
        
        PlayerShortcutController.OnShortcutKeyPress += SelectShortcut;
        PlayerShortcutController.OnShortcutUsed += ShortcutUse;
    }
    #endregion

    private void OnDestroy() {
        PlayerShortcutController.OnShortcutKeyPress -= SelectShortcut;
        PlayerShortcutController.OnShortcutUsed -= ShortcutUse;
    }

    private void Update() {

    }

    public void SelectShortcut(int shortcutNumber){
        
        if(shortcutNumber < ItemSlots.Length && !HudController.IsUsed && selectedSlotNumber != shortcutNumber){
            SelectedSlot.OnSlotChange -= UpdateSelectedShortcut;
            SelectedSlot = ItemSlots[shortcutNumber];
            selectedSlotNumber = shortcutNumber;
            SelectedSlot.OnSlotChange += UpdateSelectedShortcut;
            UpdateSelectedShortcut();
        }
        
    }

    public void UpdateSelectedShortcut(){

        PlayerAttackController.current.ChangeWeapon(null);
        PlayerBuildController.current.ChangeHoldingItem(null);
        
        Item item = SelectedSlot.Item;

        if(item is WeaponItem){

            WeaponItem weaponItem = (WeaponItem)item;
            if(weaponItem != null){
                PlayerAttackController.current.ChangeWeapon(weaponItem.WeaponPrefab);
            }

        } else if(item is PlaceableItem){

            PlaceableItem placeableItem = (PlaceableItem)item;
            if(placeableItem != null){
                PlayerBuildController.current.ChangeHoldingItem(placeableItem.PlaceablePrefab);
            }

        }
        
    }

    public void ShortcutUse(bool isRightClick){

        SelectedSlot.UseItem(isRightClick);

    }

}
