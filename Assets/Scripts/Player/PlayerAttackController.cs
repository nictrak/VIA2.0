﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField]
    private List<string> attackStrings;
    [SerializeField]
    private List<Attack> attackObjects;
    [SerializeField]
    private Weapon weapon;

    private string currentAttackString;
    private string animatedAttackString;
    private int attackFrameCounter;
    private PlayerStaminaController playerStaminaController;

    public Weapon Weapon { get => weapon; set => weapon = value; }

    // Start is called before the first frame update
    void Start()
    {
        attackFrameCounter = 0;
        currentAttackString = "";
        animatedAttackString = "";
        playerStaminaController = GetComponent<PlayerStaminaController>();
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
            PlayerRenderer.PlayerRenderState newRenderState = attackObjects[newIndex].RenderState;
            attackObjects[newIndex].DoDamage(weapon.ModifiersPrefab);
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
    public void AttackControlPerFrame(PlayerRenderer playerRenderer, Vector2 direction)
    {
        if (IsAnimatedAttack())
        {
            int index = attackStrings.IndexOf(animatedAttackString);
            if (IsFrameCounterHit(index))
            {
                UpdateAttackAnimate(playerRenderer, direction);
                attackFrameCounter = 0;
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
        }
    }

}
