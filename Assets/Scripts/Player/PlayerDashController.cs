using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashController : MonoBehaviour
{
    [SerializeField]
    private float dashVelocity;
    [SerializeField]
    private int dashFrame;
    [SerializeField]
    private int dashStamina;

    private bool isDash;
    private Vector2 dashVector;
    private int dashCounter;
    private Collider2D normalCollider;
    private PlayerStaminaController playerStaminaController;

    public bool IsDash { get => isDash; set => isDash = value; }
    public Vector2 DashVector { get => dashVector; set => dashVector = value; }

    // Start is called before the first frame update
    void Start()
    {
        playerStaminaController = GetComponent<PlayerStaminaController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (isDash)
        {
            if(dashCounter >= dashFrame)
            {
                StopDash();
            }
            else
            {
                dashCounter++;
            }
        }
    }
    public void StartDash(Vector2 direction, PlayerRenderer playerRenderer, Collider2D collider2D)
    {
        if (playerStaminaController.ConsumeStamina(dashStamina))
        {
            dashVector = direction * dashVelocity;
            isDash = true;
            playerRenderer.UpdateAnimation(PlayerRenderer.PlayerRenderState.Dash, direction);
            normalCollider = collider2D;
            normalCollider.isTrigger = true;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }
    public void StopDash()
    {
        dashCounter = 0;
        isDash = false;
        dashVector = new Vector2();
        normalCollider.isTrigger = false;
        normalCollider = null;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDash && collision.gameObject.tag == "Wall")
        {
            StopDash();
        }
    }
}
