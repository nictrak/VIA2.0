using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLayerDetector : MonoBehaviour
{
    [SerializeField]
    protected LayerMask layerMask;

    [SerializeField]
    protected List<GameObject> objs;

    protected int layer;

    protected virtual void Start() {
        layer = Helper.LayerMaskToLayer(layerMask);
        objs = new List<GameObject>();
    }

    public bool IsEmpty() {
        return objs.Count == 0;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == layer){
            objs.Add(other.gameObject);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == layer){
            objs.Remove(other.gameObject);
        }
    }
}