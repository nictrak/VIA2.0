using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototype_Tree_Heal : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.Play("Summon_bomb_0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) {
        // Debug.Log("Hit");
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "PlayerTarget")
        {
            Debug.Log("Heal");
        }
    }
}
