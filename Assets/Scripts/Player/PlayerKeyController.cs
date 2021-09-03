using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyController : MonoBehaviour
{
    [SerializeField]
    private Sprite doorOpen;
    private int currentKey;
    // Start is called before the first frame update
    void Start()
    {
        currentKey = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            currentKey = currentKey + 1;
        }
        if(collision.gameObject.tag == "Door")
        {
            if(currentKey > 0)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = doorOpen;
                collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
                currentKey = currentKey - 1;
            }
        }
    }
}
