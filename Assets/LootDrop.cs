using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<GameObject> itemDropPrefabs;
    [SerializeField]
    private List<Item> itemScripts;
    
    private List<GameObject> tempItemDropPrefabs;
    void Start()
    {
        tempItemDropPrefabs = itemDropPrefabs;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy() {
        // Use same code base as PlayerShortcutController
        for (int i = 0; i <= tempItemDropPrefabs.Count; i = i + 1) 
        {
            GameObject spawned = Instantiate(tempItemDropPrefabs[i]);
            spawned.transform.position = new Vector3( gameObject.transform.position.x + Random.Range(-1,1),gameObject.transform.position.y + Random.Range(-1,1),0);
            SpriteRenderer m_SpriteRenderer = spawned.GetComponent<SpriteRenderer>();
            
            ItemPickable itemPickable = spawned.GetComponent<ItemPickable>();
            m_SpriteRenderer.sprite = itemScripts[i].Icon;
            itemPickable.Item = itemScripts[i].Copy();

        }
        
    }
}
