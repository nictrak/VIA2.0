using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static float blockSize = Mathf.Sin(Mathf.Deg2Rad*45);
    protected int spriteSortingOrder = 30;

    #region Block Properties

    [SerializeField]
    private Transform spritesParent;
    [SerializeField]
    protected List<SpriteRenderer> spriteRenderers;
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
        spriteSortingOrder = 30;
        if (spritesParent != null)
            spritesParent.GetComponentsInChildren<SpriteRenderer>(includeInactive: true, result: spriteRenderers);
        if (boxCollider == null) {
            boxCollider = GetComponentInChildren<BoxCollider2D>();
        }
    }

    protected virtual void setBlockProperties() {

        if(item != null){

            //Collider setting
            Vector2 size = item.Size;
            boxCollider.size = new Vector2(size.y, size.x) * blockSize;
            boxCollider.offset = new Vector2((size.y-1), -(size.x-1)) * 0.5f * blockSize;

            //Sprite setting
            setSprites(item.Icons, size.x);

        }

    }

    protected virtual void setSprites(Sprite[] sprites, float width) {

        for (int i = 0; i < spriteRenderers.Count; i++){

            if( i < sprites.Length ){
                spriteRenderers[i].sprite = sprites[i];
                Vector2 spriteOffset = new Vector2( i * 0.5f, i* -0.25f);
                if(i >= width){
                    spriteOffset = new Vector2( i * 0.5f, ((2*width)-i-1)* -0.25f);
                }

                Transform spriteTransform = spritesParent.transform.GetChild(i);
                spriteTransform.position = spritesParent.TransformPoint(spriteOffset);
                spriteRenderers[i].color = Color.white;
            } else {
                spriteRenderers[i].color = Color.clear;
            }

        }

        for (int i = spriteRenderers.Count; i < sprites.Length; i++){

            //Add new obj
            GameObject spriteObject = new GameObject("Sprite_"+i, typeof(SpriteRenderer));
            Vector2 spriteOffset = new Vector2( i * 0.5f, i* -0.25f);
            if(i >= width){
                spriteOffset = new Vector2( i * 0.5f, ((2*width)-i-1)* -0.25f);
            }
            spriteObject.transform.position = (Vector2)this.transform.position + spriteOffset;
            spriteObject.transform.SetParent(spritesParent);

            //Add sprite to array
            SpriteRenderer renderer = spriteObject.GetComponent<SpriteRenderer>();
            renderer.spriteSortPoint = SpriteSortPoint.Pivot;
            renderer.sortingOrder = spriteSortingOrder;
            spriteRenderers.Add(renderer);

            renderer.sprite = sprites[i];
            
        }

    }

}