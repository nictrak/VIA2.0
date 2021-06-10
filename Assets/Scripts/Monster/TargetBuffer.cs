using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBuffer : MonoBehaviour
{
    private Vector2 targetPosition;

    public Vector2 TargetPosition { get => targetPosition; set => targetPosition = value; }

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
