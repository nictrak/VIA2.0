using UnityEngine;

[CreateAssetMenu(fileName = "New ItemDatabase", menuName = "VIA2.0/ItemDatabase", order = 0)]
public class ItemDatabase : Database
{
    [SerializeField]
    Item[] items;
    public Item GetItemReference(string itemID)
    {
        foreach(Item item in items)
        {
            if(item.ID == itemID)
            {
                return item;
            }
        }
        return null;
    }

    public Item GetItemCopy(string itemID)
    {
        Item item = GetItemReference(itemID);
        if(item == null) return null;
        return item.Copy();
    }

    #if UNITY_EDITOR
    protected override void LoadItems()
    {
        items = Helper.FindAssetsByType<Item>("Assets/Resources/Items");
    }
    #endif
}
