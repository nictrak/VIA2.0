using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCorner : MonoBehaviour
{
    private float distance;

    private bool isCurrentCorner;

    private Collider2D lastestCollider;

    public bool IsCurrentCorner { get => isCurrentCorner; set => isCurrentCorner = value; }

    public float PlayerDistance {
        get {
            if(isHitPlayer) return Vector2.Distance(transform.position, lastestCollider.transform.parent.transform.position);
            return 999999f;
        } 
    }

    private bool isHitPlayer;

    public Vector2 GetPosition { get => transform.position;}

    // Start is called before the first frame update
    void Start()
    {
        distance = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTarget")
        {
            isHitPlayer = true;
            lastestCollider = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTarget")
        {
            isHitPlayer = false;
        }

    }

}