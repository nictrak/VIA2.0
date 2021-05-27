using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int initialHealth;

    private bool isHurt;
    private bool isAlreadyHurt;
    private int currentHealth;
    private bool isDead;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        HurtControlPerFrame();
    }
    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
        currentHealth = currentHealth - damage;
        if (damage > 0) isHurt = true;
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
}
