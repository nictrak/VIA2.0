using UnityEngine;

public class ItemPickable : MonoBehaviour
{
    [SerializeField] Item item;
    public Item Item { get => item; set => item = value; }
    [SerializeField] Inventory inventory;
    [SerializeField] KeyCode itemPickupKeyCode = KeyCode.F;
    

    [SerializeField]
    private bool isInRange;

    private void Update() {

        if (isInRange && Input.GetKeyDown(itemPickupKeyCode))
        {
            Item itemToAdd = item.Copy();
            if (!inventory.AddItem(itemToAdd)) {
                itemToAdd.Destroy();
                Destroy(gameObject);
            }
            
        }
    }

    private void Start()
    {
        if(inventory == null)
        {
            inventory = Resources.FindObjectsOfTypeAll<Inventory>()[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "PlayerTarget") isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "PlayerTarget") isInRange = false;
    }
}
