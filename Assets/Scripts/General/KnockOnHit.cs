using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockOnHit : MonoBehaviour
{

    [SerializeField]
    private bool isKnock;
    [SerializeField]
    private float knockVelocity;
    [SerializeField]
    private int knockFrame;
    [SerializeField]
    private bool isEffectPlayer = true;

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
                //if (isKnock) collision.gameObject.GetComponent<PlayerKnocked>().Knocked((Vector2)transform.position - direction * velocity, knockVelocity, knockFrame);
            }
        }
    }

}
