using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryingBlock : Block
{

    #region Block Properties

    [SerializeField]
    private ColliderLayerDetector detector;

    #endregion

    protected override void OnValidate() {
        base.OnValidate();
        if (detector == null) {
            detector = GetComponentInChildren<ColliderLayerDetector>();
        }
        if(!boxCollider.isTrigger){
            boxCollider.isTrigger = true;
        }
    }

    private void FixedUpdate() {
        if(detector.IsEmpty()) {
            spriteRenderer.color = new Color(1f,1f,1f,0.5f);
        } else {
            spriteRenderer.color = new Color(1f,0,0,0.5f);
        }
    }

    public bool CanPlace(){
        return detector.IsEmpty();
    }

}