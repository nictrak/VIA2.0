using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private EquipmentPanel equipmentPanel;
    [SerializeField]
    private Image draggableItem;

    private ItemSlot draggingSlot;

    private void Awake() {

        //Setup Events
        //Right Click
        inventory.OnRightClickEvent += Equip;
        equipmentPanel.OnRightClickEvent += Unequip;
        //Begin Drag
        inventory.OnBeginDragEvent += BeginDrag;
        equipmentPanel.OnBeginDragEvent += BeginDrag;
        //End Drag
        inventory.OnEndDragEvent += EndDrag;
        equipmentPanel.OnEndDragEvent += EndDrag;
        //Drag
        inventory.OnDragEvent += Drag;
        equipmentPanel.OnDragEvent += Drag;
        //Drop
        inventory.OnDropEvent += Drop;
        equipmentPanel.OnDropEvent += Drop;

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
        if(itemSlot != null)
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
            draggingSlot.Item = dropSlot.Item;
            dropSlot.Item = draggingItem;
        }
    }

    public void Equip(EquippableItem item)
    {
        if(inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if(equipmentPanel.AddItem(item, out previousItem))
            {
                Debug.Log("Change Weapon");
                PlayerAttackController playerAttackController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttackController>();
                playerAttackController.ChangeWeapon(equipmentPanel.GetEquipedWeapon());
                if(previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
            } else {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if(!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }

}
