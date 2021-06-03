﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
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
            Health enemyHealth = enemies[i].GetComponent<Health>();
            ModifierController enemyModController = enemies[i].GetComponent<ModifierController>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                if(mods != null)
                {
                    for (int j = 0; j < mods.Count; j++)
                    {
                        enemyModController.AddModifier(mods[j]);
                    }
                }
            }
        }
    }
}
