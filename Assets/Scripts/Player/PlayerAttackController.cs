using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;

    private string currentAttackString;
    private string animatedAttackString;
    private int attackFrameCounter;
    private PlayerStaminaController playerStaminaController;
    private int currentAnimatedIndex;
    private List<Attack> attackObjects;
    private List<string> attackStrings;
    private float currentVelocity;

    public Weapon Weapon { get => weapon; set => weapon = value; }

    // Start is called before the first frame update
    void Start()
    {
        attackFrameCounter = 0;
        currentAttackString = "";
        animatedAttackString = "";
        playerStaminaController = GetComponent<PlayerStaminaController>();
        currentAnimatedIndex = 0;
        currentVelocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsAttack()
    {
        return currentAttackString.Length > 0;
    }
    public bool IsAnimatedAttack()
    {
        return animatedAttackString.Length > 0;
    }
    public bool IsAllAnimated()
    {
        return currentAttackString.Length == animatedAttackString.Length;
    }
    private bool IsFrameCounterHit(int index)
    {
        return attackFrameCounter >= attackObjects[index].Frame;
    }
    public bool IsFrameCounterZero()
    {
        return attackFrameCounter == 0;
    }
    private bool IsFrameCounterHitMoveDelay(int index)
    {
        return attackFrameCounter >= attackObjects[index].MoveDelayFrame;
    }
    private bool IsFrameCounterHitTurningPoint(int index)
    {
        return attackFrameCounter >= attackObjects[index].TurningPointFrame;
    }
    public void AddAttack(string attackKey)
    {
        string newAttackString = currentAttackString + attackKey;
        if (attackStrings.Contains(newAttackString))
        {
            int index = attackStrings.IndexOf(newAttackString);
            int stamina = attackObjects[index].Stamina;
            if(playerStaminaController.ConsumeStamina(stamina)) currentAttackString = newAttackString; 
        }
    }
    private void UpdateAttackAnimate(PlayerRenderer playerRenderer, Vector2 direction)
    {
        if (!IsAllAnimated())
        {
            string newAnimatedAttackString = currentAttackString.Substring(0, animatedAttackString.Length + 1);
            int newIndex = attackStrings.IndexOf(newAnimatedAttackString);
            currentAnimatedIndex = newIndex;
            PlayerRenderer.PlayerRenderState newRenderState = attackObjects[newIndex].RenderState;
            attackObjects[newIndex].DoDamage(weapon);
            playerRenderer.UpdateAnimation(newRenderState, direction);
            animatedAttackString = newAnimatedAttackString;
        }
        else
        {
            currentAttackString = "";
            animatedAttackString = "";
            playerRenderer.UpdateAnimation(PlayerRenderer.PlayerRenderState.Static, direction);
            attackFrameCounter = 0;
        }
    }

    public void ClearAllStack(){
        attackFrameCounter = 0;
        currentAttackString = "";
        animatedAttackString = "";
        currentAnimatedIndex = 0;
        currentVelocity = 0;
    }

    public bool CanChangeDirection(){
        return !IsAnimatedAttack() || IsFrameCounterHit(attackStrings.IndexOf(animatedAttackString));
    }

    public Vector2 AttackControlPerFrame(PlayerRenderer playerRenderer, Vector2 direction)
    {
        Vector2 res = new Vector2();
        if (IsAnimatedAttack())
        {
            int index = attackStrings.IndexOf(animatedAttackString);
            if (IsFrameCounterHitMoveDelay(currentAnimatedIndex))
            {
                //res = direction.normalized * attackObjects[currentAnimatedIndex].MoveDistance;
                res = direction.normalized * currentVelocity;
                if (IsFrameCounterHitTurningPoint(currentAnimatedIndex))
                {
                    currentVelocity -= attackObjects[currentAnimatedIndex].SlowRate;
                }
                else
                {
                    currentVelocity += attackObjects[currentAnimatedIndex].AccelerateRate;
                }
            }
            if (IsFrameCounterHit(index))
            {
                UpdateAttackAnimate(playerRenderer, direction);
                attackFrameCounter = 0;
                currentVelocity = 0;
            }
            else
            {
                attackFrameCounter++;
            }
        }
        else
        {
            UpdateAttackAnimate(playerRenderer, direction);
        }
        return res;
    }
    public bool IsEquipWeapon()
    {
        return weapon != null;
    }
    public void ChangeWeapon(Weapon newWeapon)
    {
        if (IsEquipWeapon())
        {
            Destroy(weapon.gameObject);
        }
        if(newWeapon != null)
        {
            weapon = Instantiate<Weapon>(newWeapon, transform);
            attackObjects = weapon.AttackObjects;
            attackStrings = weapon.AttackStrings;
        }
    }
    public int GetAnimatedStringLenght()
    {
        return animatedAttackString.Length;
    }
}
