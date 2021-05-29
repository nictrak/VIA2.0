using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnHit : MonoBehaviour
{

    [SerializeField]
    private GameObject gameObject;
    [SerializeField]
    private bool isEffectPlayer = true;
    [SerializeField]
    private bool isEffectEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
                GameObject spawned =  Instantiate(gameObject);
                spawned.transform.position = transform.position;
            }
            if (collision.gameObject.tag == "Enemy" && isEffectEnemy)
            {
                GameObject spawned =  Instantiate(gameObject);
                spawned.transform.position = transform.position;
            }
        }
    }

}
