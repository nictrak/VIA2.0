using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static float blockSize = Mathf.Sin(Mathf.Deg2Rad*45);

    #region Block Properties


    [SerializeField]
    private Transform spritesParent;
    [SerializeField]
    protected SpriteRenderer[] spriteRenderers;
    [SerializeField]
    protected BoxCollider2D boxCollider;

    #endregion

    [SerializeField]
    protected PlaceableItem item;

    public PlaceableItem Item {
        get { return item; }
        set {
            this.item = value;
            setBlockProperties();
        }
    }

    protected virtual void OnValidate() {
        if (spritesParent != null)
            spriteRenderers = spritesParent.GetComponentsInChildren<SpriteRenderer>();
        if (boxCollider == null) {
            boxCollider = GetComponentInChildren<BoxCollider2D>();
        }
    }

    protected virtual void setBlockProperties() {

        if(item != null){

            //Sprite setting
            //spriteRenderer.sprite = item.Icon;
            //Collider setting
            Vector2 size = item.Size;
            boxCollider.size = new Vector2(size.y, size.x) * blockSize;
            boxCollider.offset = new Vector2((size.y-1), -(size.x-1)) * 0.5f * blockSize;

        }

    }

}