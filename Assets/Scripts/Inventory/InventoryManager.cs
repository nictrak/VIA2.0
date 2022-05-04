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

    private Item draggedItemBuffer;
    private int draggedAmountBuffer;

    public ShortcutPanel ShortcutPanel { get => shortcutPanel; set => shortcutPanel = value; }

    #region Unity Function
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
        Inventory.OnBeginDragEvent += SwapWithDragSlot;
        EquipmentPanel.OnBeginDragEvent += SwapWithDragSlot;
        shortcutPanel.OnBeginDragEvent += SwapWithDragSlot;
        //End Drag
        Inventory.OnEndDragEvent += EndDrag;
        EquipmentPanel.OnEndDragEvent += EndDrag;
        shortcutPanel.OnEndDragEvent += EndDrag;
        //Drag
        Inventory.OnDragEvent += Drag;
        EquipmentPanel.OnDragEvent += Drag;
        shortcutPanel.OnDragEvent += Drag;
        //Drop
        Inventory.OnDropEvent += SwapWithDragSlot;
        EquipmentPanel.OnDropEvent += SwapWithDragSlot;
        shortcutPanel.OnDropEvent += SwapWithDragSlot;

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

    private void Start()
    {
        
    }
    
    private void Update()
    {
        if(draggedItemBuffer != null)
        {
            draggedItem.enabled = true;
            draggedItem.transform.position = Input.mousePosition;
            if(draggedAmountBuffer > 1) draggedAmount.enabled = true;
        }
        else
        {
            draggedItem.enabled = false;
            draggedAmount.enabled = false;
        }
    }
    #endregion

    #region Inventory Moving
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
                if (itemSlot.CanReceiveItem(draggedItemBuffer))
                {
                    //Set temp
                    Item tempItem = draggedItemBuffer;
                    int tempAmount = draggedAmountBuffer;
                    //swap
                    SetDraggedBuffer(itemSlot.Item, itemSlot.Amount);
                    itemSlot.Item = tempItem;
                    itemSlot.Amount = tempAmount;
                }
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
    #endregion

    public int CountItem(string itemName)
    {
        return this.Inventory.CountItem(itemName) + EquipmentPanel.CountItem(itemName) + ShortcutPanel.CountItem(itemName); 
    }
}
