using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static float blockSize = 0.7f;

    #region Block Properties

    [SerializeField]
    protected SpriteRenderer spriteRenderer;
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
        if (spriteRenderer == null) {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if (boxCollider == null) {
            boxCollider = GetComponentInChildren<BoxCollider2D>();
        }
    }

    private void setBlockProperties() {

        if(item != null){

            //Sprite setting
            spriteRenderer.sprite = item.Icon;
            //Collider setting
            Vector2 size = item.Size;
            boxCollider.size = new Vector2(size.y, size.x) * blockSize;
            boxCollider.offset = new Vector2(size.y, -size.x) * 0.5f * blockSize;

        }

    }

}