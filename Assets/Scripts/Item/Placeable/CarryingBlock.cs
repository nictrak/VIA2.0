using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryingBlock : Block
{

    #region Block Properties

    [SerializeField]
    private ColliderLayerTagDetector detector;
    [SerializeField]
    Vector2 offsetCollider;

    #endregion

    protected override void OnValidate() {
        base.OnValidate();
        spriteSortingOrder = 31;
        if (detector == null) {
            detector = GetComponentInChildren<ColliderLayerTagDetector>();
        }
        if(!boxCollider.isTrigger){
            boxCollider.isTrigger = true;
        }
    }

    private void FixedUpdate() {
        if(CanPlace()) {
            SetColor(new Color(1f,1f,1f,0.5f));
        } else {
            SetColor(new Color(1f,0,0,0.5f));
        }
    }

    public void SetColor(Color color){

        if(item != null) {
            int len = item.Icons.Length;

            for (int i = 0; i < spriteRenderers.Count; i++){

                if( i < len ){
                    spriteRenderers[i].color = color;
                } else {
                    spriteRenderers[i].color = Color.clear;
                }

            }
        }
         
    }

    protected override void setBlockProperties() {

        if(item != null){

            //Collider setting
            Vector2 size = item.Size;
            boxCollider.size = (new Vector2(size.y, size.x) * blockSize) - offsetCollider;
            boxCollider.offset = new Vector2((size.y-1), -(size.x-1)) * 0.5f * blockSize;

            //Sprite setting
            setSprites(item.Icons, size.x);

        }

    }

    public bool CanPlace(){
        return detector.IsEmpty();
    }

}