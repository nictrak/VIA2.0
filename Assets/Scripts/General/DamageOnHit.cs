using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private bool isEffectPlayer = true;
    [SerializeField]
    private bool isEffectEnemy = false;
    private List<GameObject> enemyHittedList;

    // Start is called before the first frame update
    void Start()
    {
        enemyHittedList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != null)
        {
            if (collision.gameObject.tag == "Player" && isEffectPlayer)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage, transform.position, false);
            }
            if (collision.gameObject.tag == "Enemy" && isEffectEnemy)
            {
                if (!enemyHittedList.Contains(collision.gameObject))
                {
                    enemyHittedList.Add(collision.gameObject);
                    collision.gameObject.GetComponent<Health>().TakeDamage(damage, transform.position, false);
                }
            }
        }
    }

}
