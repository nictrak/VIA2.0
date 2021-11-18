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
    private bool isSpawnLimit;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private int animationFrame;
    [SerializeField]
    private RangeSpawner LinkSpawner;

    private List<GameObject> spawneds;
    private int frameCounter;
    private bool haveLink;
    public bool IsSpawnLimit { get => isSpawnLimit; set => isSpawnLimit = value; }
    public bool HaveLink { get => haveLink; set => haveLink = value; }
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
            if ( LinkSpawner == null){
                if (innerRange.Objs.Count == 0 && outerRange.Objs.Count > 0 && spawneds.Count < maxSpawned)
                {
                    spawnInstantiateMonster(spawnedPrefab);
                    spawnAnimation("SpawnEffect");
                    frameCounter = 0;
                    HaveLink = true;
                }
            } else {
                if (LinkSpawner.HaveLink){
                    if (innerRange.Objs.Count == 0 && outerRange.Objs.Count > 0 && spawneds.Count < maxSpawned)
                    {
                        spawnInstantiateMonster(spawnedPrefab);
                        spawnAnimation("SpawnEffect");
                        frameCounter = 0;
                    }
                }
            }
              
        }
        else
        {
            frameCounter++;
        }
        // Use to let Animation run Full its Animation Frame
        if (frameCounter == animationFrame){
            
            spawnAnimation("New State");
           
            // Destroy Spawner :>
            if (spawneds.Count == maxSpawned && isSpawnLimit ) {
                Destroy(gameObject);
            }
        }
    }
    public void ClearDeathSpawned()
    {
        spawneds.RemoveAll(item => item == null);
    }

    // TODO : Still in Hardcode string animation time
    private void spawnAnimation( string animationStringTag )
    {
        animator.Play(animationStringTag);
    }

    private void spawnInstantiateMonster( GameObject monsterPrefab)
    {
        GameObject spawned = Instantiate(monsterPrefab);
        spawneds.Add(spawned);
        spawned.transform.position = transform.position;
    }
}
