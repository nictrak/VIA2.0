using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRange : MonoBehaviour
{
    private bool isHitPlayer;

    public bool IsHitPlayer { get => isHitPlayer; set => isHitPlayer = value; }

    // Start is called before the first frame update
    void Start()
    {
        isHitPlayer = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isHitPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isHitPlayer = false;
        }
    }
}
