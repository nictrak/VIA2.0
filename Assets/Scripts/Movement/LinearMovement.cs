using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{

    private float velocity;
    private Vector2 direction;
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
        Vector2 newPos = rbody.position + direction * velocity;
        rbody.MovePosition(newPos);
    }

    public void Setup(Vector2 start, Vector2 target, float velocity)
    {
        transform.position = start;
        direction = (target - start).normalized;
        this.velocity = velocity;
    }

}
