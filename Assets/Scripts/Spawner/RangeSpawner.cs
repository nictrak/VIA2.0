using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSpawner : MonoBehaviour
{
    [SerializeField]
    private TriggerRange innerRange;
    [SerializeField]
    private TriggerRange outerRange;
    [SerializeField]
    private GameObject spawnedPrefab;
    [SerializeField]
    private int maxSpawned;
    [SerializeField]
    private int spawnDelayFrame;

    [SerializeField]
    private Animator animator;
       [SerializeField]
    private int animationFrame;

    private List<GameObject> spawneds;
    private int frameCounter;


    // Start is called before the first frame update
    void Start()
    {
        frameCounter = 0;
        spawneds = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        ClearDeathSpawned();
    }
    private void FixedUpdate()
    {
        if (frameCounter >= spawnDelayFrame)
        {
            if (innerRange.Objs.Count == 0 && outerRange.Objs.Count > 0 && spawneds.Count < maxSpawned)
            {
                GameObject spawned = Instantiate(spawnedPrefab);
                spawneds.Add(spawned);
                // TODO : Still in Hardcode time
                animator.Play("SpawnEffect");
                spawned.transform.position = transform.position;
                frameCounter = 0;
            }  
        }
        else
        {
            frameCounter++;
        }
        if (frameCounter == animationFrame){
            // TODO : Still in Hardcode time
            animator.Play("New State");
        }
    }
    public void ClearDeathSpawned()
    {
        spawneds.RemoveAll(item => item == null);
    }
}
