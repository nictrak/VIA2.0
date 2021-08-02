using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Inventory Inventory;
    public EquipmentPanel EquipmentPanel;
    [SerializeField]
    private ShortcutPanel shortcutPanel;
    [SerializeField]
    private ItemSaveManager itemSaveManager;
    [SerializeField]
    private Image draggableItem;

    private ItemSlot draggingSlot;
    private WeaponItem lastWeaponItem;

    private void Awake() {

        //Setup Events
        //Right Click
        Inventory.OnRightClickEvent += Equip;
        EquipmentPanel.OnRightClickEvent += Unequip;
        //Begin Drag
        Inventory.OnBeginDragEvent += BeginDrag;
        EquipmentPanel.OnBeginDragEvent += BeginDrag;
        shortcutPanel.OnBeginDragEvent += BeginDrag;
        //End Drag
        Inventory.OnEndDragEvent += EndDrag;
        EquipmentPanel.OnEndDragEvent += EndDrag;
        shortcutPanel.OnEndDragEvent += EndDrag;
        //Drag
        Inventory.OnDragEvent += Drag;
        EquipmentPanel.OnDragEvent += Drag;
        shortcutPanel.OnDragEvent += Drag;
        //Drop
        Inventory.OnDropEvent += Drop;
        EquipmentPanel.OnDropEvent += Drop;
        shortcutPanel.OnDropEvent += Drop;

        /*if(itemSaveManager != null){
            itemSaveManager.LoadEquipment(this);
            itemSaveManager.LoadInventory(this);
        }*/
    }

    private void OnDestroy() {
        /*if(itemSaveManager != null){
            itemSaveManager.SaveEquipment(this);
            itemSaveManager.SaveInventory(this);
        }*/
    }

    private void Equip(ItemSlot itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if(equippableItem != null)
        {
            Equip(equippableItem);
        }
    }

    private void Unequip(ItemSlot itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if(equippableItem != null)
        {
            Unequip(equippableItem);
        }
    }

    private void BeginDrag(ItemSlot itemSlot){
        if(itemSlot.Item != null)
        {
            draggingSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }

    private void EndDrag(ItemSlot itemSlot){
        draggingSlot = null;
        draggableItem.enabled = false;
    }

    private void Drag(ItemSlot itemSlot){
        if(draggableItem.enabled){
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    private void Drop(ItemSlot dropSlot){
        if(draggingSlot != null){
            if(dropSlot.CanReceiveItem(draggingSlot.Item) && draggingSlot.CanReceiveItem(dropSlot.Item))
            {
                EquippableItem dragItem = draggingSlot.Item as EquippableItem;
                EquippableItem dropItem = dropSlot.Item as EquippableItem;

                /*if (draggingSlot is EquipmentSlot)
                {
                    if(dragItem != null) dragItem.Unequip(this);
                    if(dropItem != null) dropItem.Equip(this);
                }
                if (dropSlot is EquipmentSlot)
                {
                    if(dragItem != null) dragItem.Equip(this);
                    if(dropItem != null) dropItem.Unequip(this);
                }*/

                Item draggingItem = draggingSlot.Item;
                int draggingAmount = draggingSlot.Amount;

                draggingSlot.Item = dropSlot.Item;
                dropSlot.Item = draggingItem;
                
                draggingSlot.Amount = dropSlot.Amount;
                dropSlot.Amount = draggingAmount;
            }
        }
    }

    public void Equip(EquippableItem item)
    {
        if(Inventory.RemoveItem(item))
        {
            EquippableItem previousItem = EquipmentPanel.GetEquippedItem(item.EquipmentType);
            if(previousItem != null){
                Unequip(previousItem);
                EquipmentPanel.AddItem(item);
            } else if(!EquipmentPanel.AddItem(item))
            {
                Inventory.AddItem(item);
            }
        }
    }
    public void LoadEquip(EquippableItem item, int amount)
    {
        EquipmentPanel.SetItem(item, amount);
    }

    public void Unequip(EquippableItem item)
    {
        if(!Inventory.IsFull() && EquipmentPanel.RemoveItem(item))
        {
            Inventory.AddItem(item);
        }
    }
    private void ChangeWeapon()
    {
        PlayerAttackController playerAttackController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttackController>();
        playerAttackController.ChangeWeapon(EquipmentPanel.GetEquipedWeapon());
    }
    private void Update()
    {
        if(EquipmentPanel.GetItemWeapon() != lastWeaponItem)
        {
            ChangeWeapon();
        }
        lastWeaponItem = EquipmentPanel.GetItemWeapon();
    }
}
