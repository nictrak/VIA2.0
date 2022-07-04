using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryingBlock : Block
{
/*
    #region Block Properties

    [SerializeField]
    private ColliderLayerTagDetector detector;
    [SerializeField]
    Vector2 offsetCollider;

    #endregion

    protected override void OnValidate() {
        base.OnValidate();
        if (detector == null) {
            detector = GetComponentInChildren<ColliderLayerTagDetector>();
        }
        if(!boxCollider.isTrigger){
            boxCollider.isTrigger = true;
        }
    }

    private void FixedUpdate() {
        if(CanPlace()) {
            spriteRenderer.color = new Color(1f,1f,1f,0.5f);
        } else {
            spriteRenderer.color = new Color(1f,0,0,0.5f);
        }
    }

    protected override void setBlockProperties() {

        if(item != null){

            //Sprite setting
            spriteRenderer.sprite = item.Icon;
            //Collider setting
            Vector2 size = item.Size;
            boxCollider.size = (new Vector2(size.y, size.x) * blockSize) - offsetCollider;
            boxCollider.offset = new Vector2((size.y-1), -(size.x-1)) * 0.5f * blockSize;

        }

    }

    public bool CanPlace(){
        return detector.IsEmpty();
    }*/

}