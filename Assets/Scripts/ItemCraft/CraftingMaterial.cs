using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMaterial : MonoBehaviour
{
    [SerializeField]
    private CraftingMaterialItem itemData;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnValidate()
    {
        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        spriteRenderer.sprite = itemData.Icon;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    public string GetItemName()
    {
        return itemData.Name;
    }
}
