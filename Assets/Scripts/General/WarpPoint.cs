using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpPoint : MonoBehaviour
{
    [SerializeField]
    private string nextLevel;
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
        if(collision.gameObject.tag == "PlayerTarget")
        {
            if(collision.gameObject.GetComponent<PlayerIdentity>() != null)
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
                {
                    WarpSystem.WarpToScene(nextLevel);
                }
            }
        }
    }
}
