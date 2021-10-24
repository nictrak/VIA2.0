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
    private Image draggedItem;
    [SerializeField]
    private Text draggedAmount;

    private ItemSlot draggedSlot;
    private WeaponItem lastWeaponItem;

    private Item draggedItemBuffer;
    private int draggedAmountBuffer;

    public ShortcutPanel ShortcutPanel { get => shortcutPanel; set => shortcutPanel = value; }

    private void Awake() {

        //Setup Events
        //Right Click
        Inventory.OnRightClickEvent += PickOne;
        EquipmentPanel.OnRightClickEvent += PickOne;
        ShortcutPanel.OnRightClickEvent += PickOne;
        //Left Click
        Inventory.OnLeftClickEvent += SwapWithDragSlot;
        EquipmentPanel.OnLeftClickEvent += SwapWithDragSlot;
        ShortcutPanel.OnLeftClickEvent += SwapWithDragSlot;
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
    private void SetDraggedBuffer(Item item, int amount)
    {
        draggedItemBuffer = item;
        draggedAmountBuffer = amount;
        if (draggedItemBuffer != null)
        {
            if(amount > 0)
            {
                draggedItem.sprite = item.Icon;
                draggedAmount.text = amount.ToString();
            }
        }
    }
    private void SwapWithDragSlot(ItemSlot itemSlot)
    {
        if(itemSlot != null)
        {
            if(itemSlot.Item != draggedItemBuffer)
            {
                //Set temp
                Item tempItem = draggedItemBuffer;
                int tempAmount = draggedAmountBuffer;
                //swap
                SetDraggedBuffer(itemSlot.Item, itemSlot.Amount);
                itemSlot.Item = tempItem;
                itemSlot.Amount = tempAmount;
            }
            else
            {
                itemSlot.Amount = itemSlot.Amount + draggedAmountBuffer;
                if(itemSlot.Amount > itemSlot.Item.MaximunStack)
                {
                    SetDraggedBuffer(draggedItemBuffer, itemSlot.Amount - itemSlot.Item.MaximunStack);
                    itemSlot.Amount = itemSlot.Item.MaximunStack;
                }
                else
                {
                    SetDraggedBuffer(null, 0);
                }
            }
        }
    }

    private void PickOne(ItemSlot itemSlot)
    {
        if(itemSlot != null)
        {
            if(draggedItemBuffer == null)
            {
                SetDraggedBuffer(itemSlot.Item, 1);
                itemSlot.Amount = itemSlot.Amount - 1;
            }
            else
            {
                if (itemSlot.Item == draggedItemBuffer)
                {
                    if(draggedAmountBuffer + 1 <= draggedItemBuffer.MaximunStack)
                    {
                        SetDraggedBuffer(draggedItemBuffer, draggedAmountBuffer + 1);
                        itemSlot.Amount = itemSlot.Amount - 1;
                    }
                }
            }
        }
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
            draggedSlot = itemSlot;
            draggedItem.sprite = itemSlot.Item.Icon;
            draggedItem.transform.position = Input.mousePosition;
            draggedItem.enabled = true;
        }
    }

    private void EndDrag(ItemSlot itemSlot){
        draggedSlot = null;
        draggedItem.enabled = false;
    }

    private void Drag(ItemSlot itemSlot){
        if(draggedItem.enabled){
            draggedItem.transform.position = Input.mousePosition;
        }
    }

    private void Drop(ItemSlot dropSlot){
        if(draggedSlot != null){
            if(dropSlot.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(dropSlot.Item))
            {
                EquippableItem dragItem = draggedSlot.Item as EquippableItem;
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

                Item draggingItem = draggedSlot.Item;
                int draggingAmount = draggedSlot.Amount;

                draggedSlot.Item = dropSlot.Item;
                dropSlot.Item = draggingItem;
                
                draggedSlot.Amount = dropSlot.Amount;
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
        if(draggedItemBuffer != null)
        {
            draggedItem.enabled = true;
            draggedAmount.enabled = true;
            draggedItem.transform.position = Input.mousePosition;
        }
        else
        {
            draggedItem.enabled = false;
            draggedAmount.enabled = false;
        }
    }
    public int CountItem(string itemName)
    {
        return this.Inventory.CountItem(itemName) + EquipmentPanel.CountItem(itemName) + ShortcutPanel.CountItem(itemName); 
    }
}
