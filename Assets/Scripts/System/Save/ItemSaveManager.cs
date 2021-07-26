using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaveManager : MonoBehaviour
{
    [SerializeField]
    private ItemDatabase itemDatabase;
    private const string InventoryFileName = "Inventory";
    private const string EquipmentFileName = "Equipment";

    public void LoadInventory(InventoryManager IM)
    {
        ItemContainerSaveData savedData = ItemSaveIO.LoadItems(InventoryFileName);
        if(savedData == null) return;

        //IM.Inventory.Clear();

        for(int i = 0; i < savedData.SavedSlots.Length; i++)
        {
            ItemSlot itemSlot = IM.Inventory.ItemSlots[i];
            ItemSlotSaveData savedSlot = savedData.SavedSlots[i];

            if(savedSlot == null)
            {
                itemSlot.Item = null;
                itemSlot.Amount = 0;
            } else {
                itemSlot.Item = itemDatabase.GetItemCopy(savedSlot.ItemID);
                itemSlot.Amount = savedSlot.Amount;
            }
        }
    }

    public void LoadEquipment(InventoryManager IM)
    {
        ItemContainerSaveData savedData = ItemSaveIO.LoadItems(EquipmentFileName);
        if(savedData == null) return;

        //IM.EquipmentPanel.Clear();

        foreach (ItemSlotSaveData savedSlot in savedData.SavedSlots)
        {
            if(savedSlot == null) continue;

            Item item = itemDatabase.GetItemCopy(savedSlot.ItemID);
            IM.LoadEquip((EquippableItem) item, savedSlot.Amount);
        }
    }

    public void SaveInventory(InventoryManager IM)
    {
        SaveItems(IM.Inventory.ItemSlots, InventoryFileName);
    }

    public void SaveEquipment(InventoryManager IM)
    {
        SaveItems(IM.EquipmentPanel.EquipmentSlots, EquipmentFileName);
    }

    private void SaveItems(IList<ItemSlot> itemSlots, string fileName)
    {
        var saveData = new ItemContainerSaveData(itemSlots.Count);

        for(int i = 0; i < saveData.SavedSlots.Length; i++)
        {
            ItemSlot itemSlot = itemSlots[i];

            if(itemSlot.Item == null)
            {
                saveData.SavedSlots[i] = null;
            } else {
                saveData.SavedSlots[i] = new ItemSlotSaveData(itemSlot.Item.ID, itemSlot.Amount);
            }
        }

        ItemSaveIO.SaveItems(saveData, fileName);
    }
}
