using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLayerTagDetector : ColliderLayerDetector
{
    
    [SerializeField]
    private String tag;

    [SerializeField]
    private List<GameObject> taggedObjs;

    protected override void Start() {
        base.Start();
        taggedObjs = new List<GameObject>();
    }

    public int tagCount() {
        return taggedObjs.Count;
    }


    protected override void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == layer) {
            if(other.gameObject.tag == tag){
                taggedObjs.Add(other.gameObject);
            } else {
                objs.Add(other.gameObject);
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == layer) {
            if(other.gameObject.tag == tag){
                taggedObjs.Remove(other.gameObject);
            } else {
                objs.Remove(other.gameObject);
            }
        }
    }
}