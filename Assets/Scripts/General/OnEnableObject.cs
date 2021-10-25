using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableObject : MonoBehaviour
{

[SerializeField]
    private string tagTarget;

    [SerializeField]
    private GameObject ObjectPrefab;
    // Start is called before the first frame update
    private GameObject objectPrefab;
    void Start()
    {
        objectPrefab = ObjectPrefab;
        objectPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tagTarget)
        {
            objectPrefab.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTarget)
        {
            objectPrefab.SetActive(false);
        }
    }
}
