using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCorner : MonoBehaviour
{
    private float distance;

    private bool isCurrentCorner;

    public bool IsCurrentCorner { get => isCurrentCorner; set => isCurrentCorner = value; }

    public float PlayerDistance { get => distance;}

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
            distance = Vector2.Distance(transform.position, collision.transform.position);
        }

        if (collision.tag == "Boss")
        {
            isCurrentCorner = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTarget")
        {
            distance = 0f;
        }

        if (collision.tag == "Boss")
        {
            isCurrentCorner = false;
        }
    }

}