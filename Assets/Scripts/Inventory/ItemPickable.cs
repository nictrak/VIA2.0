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
            }
            Destroy(gameObject);
        }
    }

     private void OnValidate()
    {
        if(inventory == null)
        {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        isInRange = false;
    }
}
