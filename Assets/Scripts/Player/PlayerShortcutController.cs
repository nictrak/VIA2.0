using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShortcutController : MonoBehaviour
{
    [SerializeField]
    private GameObject itemCraftPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseShortcut(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseShortcut(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseShortcut(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseShortcut(3);
        }
    }
    public void UseShortcut(int index)
    {
        ShortcutPanel shortcutPanel = GameObject.FindGameObjectWithTag("Shortcut").GetComponent<ShortcutPanel>();
        GameObject spawned = Instantiate(itemCraftPrefab);
        spawned.transform.position = transform.position;
        CraftingMaterial craftingMaterial = spawned.GetComponent<CraftingMaterial>();
        ItemPickable itemPickable = spawned.GetComponent<ItemPickable>();
        itemPickable.Item = shortcutPanel.ShortcutSlots[index].Item.Copy();
        craftingMaterial.ItemData = (CraftingMaterialItem)shortcutPanel.ShortcutSlots[index].Item.Copy();
    }
}
