using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : NeedTarget
{
    private Vector2 moveVector;
    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovePerFrame();
    }

    private void MovePerFrame()
    {
        Vector2 newPos = rbody.position + moveVector;
        rbody.MovePosition(newPos);
    }

    public override void SetTarget(Vector2 start, Vector2 target, float velocity)
    {
        transform.position = start;
        moveVector = (target - start).normalized * velocity;
    }
}
