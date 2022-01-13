using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject itemCraftPrefab;
    [SerializeField]
    private Item itemScript;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        // Use same code base as PlayerShortcutController
        GameObject spawned = Instantiate(itemCraftPrefab);
        
        spawned.transform.position = transform.position;
        CraftingMaterial craftingMaterial = spawned.GetComponent<CraftingMaterial>();
        craftingMaterial.ItemData = (CraftingMaterialItem)itemScript.Copy();

        ItemPickable itemPickable = spawned.GetComponent<ItemPickable>();
        itemPickable.Item = itemScript.Copy();

        Animation itemAnimation = spawned.GetComponent<Animation>();
        // Debug.Log(itemScript.name);
        itemAnimation.Play(itemScript.name);
        // Vector3 pos = new Vector3(Random.Range(-1,1),Random.Range(-1,1),0);
        // Instantiate(dropOnDamaged, dropOnDamaged.position);
    }
}
