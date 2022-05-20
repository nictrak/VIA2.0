using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static float blockSize = 0.7f;

    #region Block Properties

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private BoxCollider2D collider;

    #endregion

    [SerializeField]
    private PlaceableItem item;

    public PlaceableItem Item {
        get { return item; }
        set {
            this.item = value;
            setBlockProperties();
        }
    }

    private void setBlockProperties() {

        if(item != null){

            //Sprite setting
            spriteRenderer.sprite = item.Icon;
            //Collider setting
            Vector2 size = item.Size;
            collider.size = new Vector2(size.y, size.x) * blockSize;
            collider.offset = new Vector2(size.y, -size.x) * 0.5f * blockSize;

        }

    }

}