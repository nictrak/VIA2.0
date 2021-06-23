using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaminaController : MonoBehaviour
{
    [SerializeField]
    private int maxStamina;
    [SerializeField]
    private int initialStamina;
    [SerializeField]
    private RectTransform staminaBar;
    [SerializeField]
    private int regenFrame;
    [SerializeField]
    private int regenedStamina;

    private int currentStamina;
    private float barWidth;
    private int frameCounter;

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = initialStamina;
        barWidth = -1;
        frameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(staminaBar != null)
        {
            UpdateStaminaBar();
        }
    }
    private void FixedUpdate()
    {
        StaminaRegenPerFrame();
    }
    private void UpdateStaminaBar()
    {
        if (barWidth == -1)
        {
            barWidth = staminaBar.sizeDelta.x;
        }
        float currentWidth = barWidth * currentStamina / maxStamina;
        staminaBar.sizeDelta = new Vector2(currentWidth, staminaBar.sizeDelta.y);
    }
    public bool ConsumeStamina(int stamina)
    {
        if(currentStamina >= stamina)
        {
            currentStamina = currentStamina - stamina;
            return true;
        }
        return false;
    }
    private void StaminaRegenPerFrame()
    {
        if(frameCounter >= regenFrame)
        {
            frameCounter = 0;
            currentStamina += regenedStamina;
            if (currentStamina > maxStamina) currentStamina = maxStamina;
        }else
        {
            frameCounter++;
        }
    }
}
