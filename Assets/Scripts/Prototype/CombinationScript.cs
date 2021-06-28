using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationScript : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void OnTriggerStay2D(Collider2D collision) {
        string gameObjectName;
        string collisionObjectName;

        gameObjectName = gameObject.name.Substring(0);
        collisionObjectName = collision.gameObject.name.Substring(0);
        if (collisionObjectName == gameObjectName && gameObjectName == "summon_1(Clone)" ){
            Debug.Log("J key was released.");
            Instantiate(Resources.Load("summon_2", typeof(GameObject)), new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
            Debug.Log("Create new combination");
            // GameObject instance = Instantiate(Resources.Load("summon_2", typeof(GameObject))) as GameObject;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
