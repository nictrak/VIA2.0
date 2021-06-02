using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FleeController : MonoBehaviour
{
    [SerializeField]
    private float fleeVelocity;

    private bool isEnable;
    private AIDestinationSetter destinationSetter;
    private Rigidbody2D rgbody;

    public bool IsEnable { get => isEnable; set => isEnable = value; }

    // Start is called before the first frame update
    void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        rgbody = GetComponent<Rigidbody2D>();
        isEnable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (isEnable) MovePerFrame();
    }
    private Vector2 CalFleeVector()
    {
        Vector2 res = (rgbody.position - (Vector2)destinationSetter.target.position).normalized * fleeVelocity;
        return res;
    }
    private void MovePerFrame()
    {
        Vector2 newPos = rgbody.position + CalFleeVector();
        rgbody.MovePosition(newPos);
    }
}
