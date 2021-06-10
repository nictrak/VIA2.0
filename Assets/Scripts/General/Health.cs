using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int initialHealth;
    [SerializeField]
    private RectTransform healthBar;

    private bool isHurt;
    private bool isAlreadyHurt;
    private int currentHealth;
    private bool isDead;
    private float barWidth;

    public bool IsDead { get => isDead; set => isDead = value; }
    public bool IsHurt { get => isHurt; set => isHurt = value; }

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        isHurt = false;
        isAlreadyHurt = false;
        currentHealth = initialHealth;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        barWidth = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar != null)
        {
            UpdateHealthBar();
        }
    }
    private void FixedUpdate()
    {
        HurtControlPerFrame();
    }
    private void UpdateHealthBar()
    {
        if(barWidth == -1)
        {
            barWidth = healthBar.sizeDelta.x;
        }
        float currentWidth = barWidth * currentHealth / maxHealth;
        healthBar.sizeDelta = new Vector2(currentWidth, healthBar.sizeDelta.y);
    }
    public void TakeDamage(int damage, bool doHurt = true)
    {
        currentHealth = currentHealth - damage;
        if (damage > 0 && doHurt) isHurt = true;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void Heal(int point)
    {
        currentHealth = currentHealth + point;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    private void HurtControlPerFrame()
    {
        if (isHurt)
        {
            if (isAlreadyHurt)
            {
                isHurt = false;
                isAlreadyHurt = false;
            }
            else
            {
                isAlreadyHurt = true;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 1);
        Vector3 start = transform.position + new Vector3(-1, 1, 0);
        Vector3 end = start + new Vector3((float)currentHealth / (float)maxHealth, 0, 0);
        Gizmos.DrawLine(start, end);
    }
}
