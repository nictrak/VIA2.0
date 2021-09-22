using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FleeController : MonoBehaviour
{
    [SerializeField]
    private float fleeVelocity;
    // Add random move
    [SerializeField]
    private float rngMoveX = 1;
    [SerializeField]
    private float rngMoveY = 1;

    private bool isEnable;
    private AIDestinationSetter destinationSetter;
    private Rigidbody2D rgbody;
    private Vector2 rgnPosition;

    public bool IsEnable { get => isEnable; set => isEnable = value; }

    // Start is called before the first frame update
    void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        rgbody = GetComponent<Rigidbody2D>();
        isEnable = false;
        //Add random range 
        // Alpha code In case : random is manual input random just easy to modified and testing   
        rgnPosition = new Vector2(Random.Range(-1*rngMoveX, rngMoveX), Random.Range(-1*rngMoveY, rngMoveY) );
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

        Vector2 res = (rgbody.position - (Vector2)destinationSetter.target.position + rgnPosition).normalized * fleeVelocity;
        return res;
    }
    private void MovePerFrame()
    {
        Vector2 newPos = rgbody.position + CalFleeVector();
        rgbody.MovePosition(newPos);
    }
}
