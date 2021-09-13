using UnityEngine;

public class ItemPickable : MonoBehaviour
{
    [SerializeField] Item item;
    public Item Item { get => item; set => item = value; }
    private Inventory inventory;
    [SerializeField] KeyCode itemPickupKeyCode = KeyCode.F;
    private SpriteRenderer renderer;
    

    private bool isInRange;

    private void Update() {

        if (isInRange && Input.GetKeyDown(itemPickupKeyCode))
        {
            if (inventory == null)
            {
                inventory = Resources.FindObjectsOfTypeAll<Inventory>()[0];
            }
            Item itemToAdd = item.Copy();
            if (!inventory.AddItem(itemToAdd)) {
                itemToAdd.Destroy();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }

    private void Start()
    {
        UpdateSprite();
    }
    private void OnValidate()
    {
        UpdateSprite();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "PlayerTarget")
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "PlayerTarget") isInRange = false;
    }
    private void UpdateSprite()
    {
        if(renderer == null)
        {
            renderer =  GetComponent<SpriteRenderer>();
        }
        renderer.sprite = item.Icon;
    }
}
