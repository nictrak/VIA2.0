using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLayerDetector : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private List<GameObject> objs;

    private int layer;

    private void Start() {
        layer = Helper.LayerMaskToLayer(layerMask);
    }

    public bool IsEmpty() {
        return objs.Count == 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == layer){
            objs.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == layer){
            objs.Remove(other.gameObject);
        }
    }
}