using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CraftingMaterial : MonoBehaviour
{
    [SerializeField]
    private CraftingMaterialItem itemData;
    private SpriteRenderer spriteRenderer;

    public CraftingMaterialItem ItemData { get => itemData; set => itemData = value; }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemData.Icon;
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
        CraftingMaterial other = collision.gameObject.GetComponent<CraftingMaterial>();
        (string, string) materials = (GetItemName(), other.GetItemName());
        if (CraftingSystem.CraftingHash.ContainsKey(materials))
        {
            if (String.Compare(other.GetItemName(), GetItemName()) > 0)
            {
                GameObject spawned = Instantiate(CraftingSystem.CraftingHash[materials]);
                spawned.transform.position = transform.position;
            }
           
            Destroy(gameObject);
        }
    }
    public string GetItemName()
    {
        return itemData.Name;
    }
}
