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
    [SerializeField]
    private GameObject hitEffectPrefab;
    [SerializeField]
    private string charName;
    [SerializeField]
    private Item dropOnDamaged;
    [SerializeField]
    private Color damageColor;
    [SerializeField]
    [Range(0.0F, 1.0F)]
    private float chopResistance;
    [SerializeField]
    [Range(0.0F, 1.0F)]
    private float strikeResistance;
    [SerializeField]
    [Range(0.0F, 1.0F)]
    private float pierceResistance;
    [SerializeField]
    [Range(0.0F, 1.0F)]
    private float voidResistance;
    [SerializeField]
    [Range(0.0F, 1.0F)]
    private float electricResistance;
    [SerializeField]
    [Range(0.0F, 1.0F)]
    private float fireResistance;
    [SerializeField]
    [Range(0.0F, 1.0F)]
    private float frostResistance;
    [SerializeField]
    private bool isTurnRedWhenHurt;

    private bool isHurt;
    private bool isAlreadyHurt;
    private int currentHealth;
    private bool isDead;
    private float barWidth;

    public bool IsDead { get => isDead; set => isDead = value; }
    public bool IsHurt { get => isHurt; set => isHurt = value; }

    [SerializeField]
    private List<SpriteRenderer> spriteRenderer;
    [SerializeField]
    [Range(0.0F, 1.0F)]
    private float knockbackRange = 0.5f;
    private Rigidbody2D rb;

    private bool attacked = false;
	private float attackedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        isHurt = false;
        isAlreadyHurt = false;
        currentHealth = initialHealth;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        barWidth = -1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar != null)
        {
            UpdateHealthBar();
        }
        if(attacked && Time.time > attackedTime + 0.25f && spriteRenderer!=null ) {
            foreach (SpriteRenderer part in spriteRenderer) 
                {
                    if (part != null){
                        part.color = Color.white;
                    }
                }
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
    public void TakeDamage(int damage, Vector3 damageDirection, bool isKnockback, bool doHurt = true, DamageSystem.DamageSubType damageSubType = DamageSystem.DamageSubType.Pure)
    {
        int calculateDamage = CalculateDamage(damage, damageSubType);
        currentHealth = currentHealth - calculateDamage;
        if(calculateDamage > 0 && spriteRenderer!=null){
            foreach (SpriteRenderer part in spriteRenderer) 
            {
                if (part != null){
                    part.color = Color.red;
                }
            }
            // spriteRenderer.color = Color.red;
            attacked = true;
		    attackedTime = Time.time;
            if(rb!=null && isKnockback){
                Vector3 moveDirection = transform.position - damageDirection;
                rb.AddForce(moveDirection.normalized * knockbackRange * 1.6f, ForceMode2D.Impulse);
            }
        }
        if (damage > 0 && doHurt)
        {
            isHurt = true;
            if (isTurnRedWhenHurt && gameObject.tag =="Player")
            {
                ScreenRed.StartDamage();
            }
            if(dropOnDamaged != null)
            {
                Inventory inventory = Resources.FindObjectsOfTypeAll<Inventory>()[0];
                inventory.AddItem(dropOnDamaged);
            }
            if(hitEffectPrefab != null)
            {
                GameObject spawned = Instantiate(hitEffectPrefab);
                spawned.transform.position = transform.position;
            }
        }
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            if (!isDead)
            {
                QuestSystem.SendQuestMessage("Kill " + charName);
                isDead = true;
            }
        }
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(GetComponent<BreakableObjectIdentity>() == null) DamageTextFactory.InstantiateDamageText(transform.position, damage, damageSubType, damageColor);
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
    // new calculate damage
    private int CalculateDamage(int damage, DamageSystem.DamageSubType damageSubType)
    {
        int newDamage = damage;
        if(damageSubType == DamageSystem.DamageSubType.Chop)
        {
            newDamage = (int) ((1f - chopResistance) * newDamage);
        }
        else if (damageSubType == DamageSystem.DamageSubType.Strike)
        {
            newDamage = (int)((1f - strikeResistance) * newDamage);
        }
        else if (damageSubType == DamageSystem.DamageSubType.Pierce)
        {
            newDamage = (int)((1f - pierceResistance) * newDamage);
        }
        else if (damageSubType == DamageSystem.DamageSubType.Void)
        {
            newDamage = (int)((1f - voidResistance) * newDamage);
        }
        else if (damageSubType == DamageSystem.DamageSubType.Fire)
        {
            newDamage = (int)((1f - fireResistance) * newDamage);
        }
        else if (damageSubType == DamageSystem.DamageSubType.Electric)
        {
            newDamage = (int)((1f - electricResistance) * newDamage);
        }
        else if (damageSubType == DamageSystem.DamageSubType.Frost)
        {
            newDamage = (int)((1f - frostResistance) * newDamage);
        }
        if(newDamage == 0 && damage > 0)
        {
            newDamage = 1;
        }
        return newDamage;
    }
}
