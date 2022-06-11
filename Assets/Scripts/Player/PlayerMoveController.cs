using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    private float moveVelocity;

    // Calculation field
    private Vector2 moveDirection;
    private Vector2 lastestNonZeroMoveDirection;
    private Vector2 lastestAttackDirection;
    private List<float> moveSpeedModifiers;
    
    // In same object field
    private Rigidbody2D rgbody;
    private PlayerAttackController playerAttackController;
    private PlayerBuildController playerBuildController;
    private PlayerDashController playerDashController;
    private Collider2D normalCollider;
    private ModifierController modifierController;
    private PlayerKnockController playerKnockController;
    private Health health;

    // In child field
    private PlayerRenderer playerRenderer;

    // Buffer field
    private Vector2 centerMousePosition;

    // Action permission field
    private bool canMove;
    private bool canUpdateMoveDirection;
    private bool canAttack;
    private bool canDash;

    public Vector2 LastestNonZeroMoveDirection { get => lastestNonZeroMoveDirection; set => lastestNonZeroMoveDirection = value; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public bool CanUpdateMoveDirection { get => canUpdateMoveDirection; set => canUpdateMoveDirection = value; }
    public bool CanAttack { get => canAttack; set => canAttack = value; }
    public bool CanDash { get => canDash; set => canDash = value; }
    public List<float> MoveSpeedModifiers { get => moveSpeedModifiers; set => moveSpeedModifiers = value; }
    public static PlayerMoveController current;

    // Start is called before the first frame update
    void Start()
    {
        current = this;

        rgbody = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponentInChildren<PlayerRenderer>();
        playerAttackController = GetComponent<PlayerAttackController>();
        playerBuildController = GetComponent<PlayerBuildController>();
        playerDashController = GetComponent<PlayerDashController>();
        normalCollider = GetComponent<Collider2D>();
        modifierController = GetComponent<ModifierController>();
        playerKnockController = GetComponent<PlayerKnockController>();
        canMove = true;
        canUpdateMoveDirection = true;
        canAttack = true;
        canDash = true;
        centerMousePosition = new Vector2(Screen.width / 2, Screen.height / 2);
        moveDirection = new Vector2();
        lastestNonZeroMoveDirection = new Vector2(0, -1);
        MoveSpeedModifiers = new List<float>();
        health = GetComponent<Health>();

    }

    private void OnDestroy() {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (canUpdateMoveDirection && !HudController.IsUsed) UpdateMoveDirection();
        if (Input.GetKeyDown(KeyCode.Space) && canDash && !HudController.IsUsed && !playerDashController.IsDash)
        {
            playerDashController.StartDash(lastestNonZeroMoveDirection, playerRenderer, normalCollider);
            playerAttackController.ClearAllStack();
        }
    }
    // Fixed frame update
    private void FixedUpdate()
    {
        if (canMove && !HudController.IsUsed) MovePerFrame();
    }

    public void WeaponUsedHandler(bool isRightClick){

        if (isRightClick && canAttack && playerAttackController.IsEquipWeapon() && !HudController.IsUsed)
        {
            playerAttackController.AddAttack("a");
        }
        if (!isRightClick && canAttack && playerAttackController.IsEquipWeapon() && !HudController.IsUsed)
        {
            playerAttackController.AddAttack("b");
        }

    }

    public bool BlockUsedHandler(bool isRightClick){

        if (isRightClick && canAttack && playerBuildController.IsCarryingBlock() && !HudController.IsUsed)
        {
            return playerBuildController.PlaceBlock();
        }

        return false;

    }

    private Vector2 CalMouseDirection()
    {
        return ((Vector2)Input.mousePosition - centerMousePosition).normalized;
    }

    // Start move method
    private Vector2 GetInputMoveDirection()
    {
        Vector2 res = new Vector2(Input.GetAxisRaw("Horizontal") * Mathf.Pow(3, 0.5f), Input.GetAxisRaw("Vertical"));
        return res.normalized;
    }
    private void UpdateMoveDirection()
    {
        moveDirection = GetInputMoveDirection();
        if (moveDirection.magnitude > 0.001)
        {
            lastestNonZeroMoveDirection = moveDirection;
        }
    }
    private Vector2 CalMoveVector()
    {
        float mod = 1f;
        for(int i = 0; i < moveSpeedModifiers.Count; i++)
        {
            mod = mod * (float)moveSpeedModifiers[i];
        }
        return moveDirection * moveVelocity * (playerAttackController.IsAttack()?0f:1f) * mod;
    }
    private void Move(Vector2 moveVector)
    {
        Vector2 newPosition = rgbody.position + moveVector;
        rgbody.MovePosition(newPosition);
    }
    private void MovePerFrame()
    {
        if (health.IsDead)
        {
            playerRenderer.UpdateAnimation(PlayerRenderer.PlayerRenderState.Dead, moveDirection);
        }
        if (playerKnockController.IsKnocked)
        {
            Move(playerKnockController.KnockedVector);
        }
        else if (playerDashController.IsDash)
        {
            Move(playerDashController.DashVector);
        }
        else if (playerAttackController.IsAttack())
        {
            if(playerAttackController.CanChangeDirection()){
                lastestAttackDirection = lastestNonZeroMoveDirection;
            }
            Move(playerAttackController.AttackControlPerFrame(playerRenderer, lastestAttackDirection));
        }
        else if (moveDirection.magnitude > 0.001)
        {
            lastestAttackDirection = lastestNonZeroMoveDirection;
            if(playerBuildController.IsCarryingBlock()){
                playerRenderer.UpdateAnimation(PlayerRenderer.PlayerRenderState.RunHoldBlock, moveDirection);
            } else if(playerAttackController.IsEquipWeapon()){
                playerRenderer.UpdateAnimation(PlayerRenderer.PlayerRenderState.RunHoldWeapon, moveDirection);
            } else {
                playerRenderer.UpdateAnimation(PlayerRenderer.PlayerRenderState.Run, moveDirection);
            }
            Move(CalMoveVector());
        }
        else
        {
            lastestAttackDirection = lastestNonZeroMoveDirection;
            if(playerBuildController.IsCarryingBlock()){
                playerRenderer.UpdateAnimation(PlayerRenderer.PlayerRenderState.StaticHoldBlock, lastestNonZeroMoveDirection);
            } else if(playerAttackController.IsEquipWeapon()){
                playerRenderer.UpdateAnimation(PlayerRenderer.PlayerRenderState.StaticHoldWeapon, lastestNonZeroMoveDirection);
            } else {
                playerRenderer.UpdateAnimation(PlayerRenderer.PlayerRenderState.Static, lastestNonZeroMoveDirection);
            }
        }
    }
    // End of move method

    //Test Trigger Debuff
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "Debuff")
        {
            Debuff debuff = collision.gameObject.GetComponent(typeof(Debuff)) as Debuff;
            debuff.Apply(gameObject);
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "Debuff")
        {
            Debuff debuff = collision.gameObject.GetComponent(typeof(Debuff)) as Debuff;
            debuff.RemoveEffect(gameObject);
        }*/
    }

    public void SetMoveVelocity(float velocity){

        moveVelocity = velocity;

    }

    public float GetMoveVelocity(){

        return moveVelocity;

    }

}
