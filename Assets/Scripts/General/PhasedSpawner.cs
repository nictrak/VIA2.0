using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasedSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies;

    private int checkFrame;
    private bool isSpawn;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        checkFrame = 50;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (enemies.Count > 0)
        {
            if(counter >= checkFrame)
            {
                if (isSpawn)
                {
                    GameObject spawned = Instantiate(enemies[0]);
                    spawned.transform.position = transform.position;
                    spawned.SetActive(true);
                    enemies.RemoveAt(0);
                    isSpawn = false;
                }
                else if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
                {
                    isSpawn = true;
                }
                counter = 0;
            }
            else
            {
                counter++;
            }
        }
    }
}
