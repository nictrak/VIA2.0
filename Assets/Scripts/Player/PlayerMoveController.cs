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
    private PlayerAttackController playerAttackController;

    // In child field
    private PlayerRenderer playerRenderer;

    // Buffer field
    private Vector2 centerMousePosition;

    // Action permission field
    private bool canMove;
    private bool canUpdateMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponentInChildren<PlayerRenderer>();
        playerAttackController = GetComponent<PlayerAttackController>();
        canMove = true;
        canUpdateMoveDirection = true;
        centerMousePosition = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(canUpdateMoveDirection) UpdateMoveDirection();
        if (Input.GetMouseButtonDown(0))
        {
            playerAttackController.AddAttack("a");
        }
        if (Input.GetMouseButtonDown(1))
        {
            playerAttackController.AddAttack("b");
        }
    }
    // Fixed frame update
    private void FixedUpdate()
    {
        if (canMove) MovePerFrame();
    }

    private Vector2 CalMouseDirection()
    {
        return ((Vector2)Input.mousePosition - centerMousePosition).normalized;
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
        return moveDirection * moveVelocity * (playerAttackController.IsAttack()?0f:1f);
    }
    private void Move(Vector2 moveVector)
    {
        Vector2 newPosition = rgbody.position + moveVector;
        rgbody.MovePosition(newPosition);
    }
    private void MovePerFrame()
    {
        Move(CalMoveVector());
        if (playerAttackController.IsAttack())
        {
            playerAttackController.AttackControlPerFrame(playerRenderer, CalMouseDirection());
        }
        else if (moveDirection.magnitude > 0.001)
        {
            playerRenderer.UpdateAnimation(PlayerRenderer.PlayerRenderState.Run, moveDirection);
        }
        else
        {
            playerRenderer.UpdateAnimation(PlayerRenderer.PlayerRenderState.Static, moveDirection);
        }
    }
    // End of move method

    //Test Trigger Debuff
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Debuff")
        {
            Debuff debuff = collision.gameObject.GetComponent(typeof(Debuff)) as Debuff;
            debuff.Apply(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Debuff")
        {
            Debuff debuff = collision.gameObject.GetComponent(typeof(Debuff)) as Debuff;
            debuff.RemoveEffect(gameObject);
        }
    }

    public void SetMoveVelocity(float velocity){

        moveVelocity = velocity;

    }

    public float GetMoveVelocity(){

        return moveVelocity;

    }

}
