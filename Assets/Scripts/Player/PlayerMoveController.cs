using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    private float moveVelocity;

    // Calculation field
    private Vector2 moveDirection;

    // In same object field
    private Rigidbody2D rgbody;

    // Action permission field
    private bool canMove;
    private bool canUpdateMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponent<Rigidbody2D>();
        canMove = true;
        canUpdateMoveDirection = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canUpdateMoveDirection) UpdateMoveDirection();
    }
    // Fixed frame update
    private void FixedUpdate()
    {
        if (canMove) MovePerFrame();
    }

    // Start move method
    private Vector2 GetInputMoveDirection()
    {
        Vector2 res = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return res.normalized;
    }
    private void UpdateMoveDirection()
    {
        moveDirection = GetInputMoveDirection();
    }
    private Vector2 CalMoveVector()
    {
        return moveDirection * moveVelocity;
    }
    private void Move(Vector2 moveVector)
    {
        Vector2 newPosition = rgbody.position + moveVector;
        rgbody.MovePosition(newPosition);
    }
    private void MovePerFrame()
    {
        Move(CalMoveVector());
    }
    // End of move method
}
