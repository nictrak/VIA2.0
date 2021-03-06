using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            enemies.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Remove(collision.gameObject);
        }
    }
    public void DoDamageAll(int damage, List<Modifier> mods = null)
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i] != null)
            {
                Health enemyHealth = enemies[i].GetComponent<Health>();
                ModifierController enemyModController = enemies[i].GetComponent<ModifierController>();
                if (enemyHealth != null)
                {
                    BreakableObjectIdentity breakableObjectIdentity = enemies[i].GetComponent<BreakableObjectIdentity>();
                    if (breakableObjectIdentity != null)
                    {
                        enemyHealth.TakeDamage(1, transform.position, false);
                    }
                    else
                    {
                        enemyHealth.TakeDamage(damage, transform.position, true);
                    }
                    if (mods != null)
                    {
                        for (int j = 0; j < mods.Count; j++)
                        {
                            Modifier newMod = Instantiate<Modifier>(mods[j]);
                            PortionTime portion = newMod.GetComponent<PortionTime>();
                            if (portion != null)
                            {
                                Destroy(portion);
                            }
                            Debug.Log(enemies[i]);
                            enemyModController.AddModifier(newMod);
                            Destroy(newMod.gameObject);
                        }
                    }
                }
            }
        }
    }
}
