using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignite : Modifier
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private int frameRate;

    private Health health;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponentInParent<Health>();
        counter = 0;
        IsEnable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (IsEnable) RunPerFrame();
        TimeCounterPerFrame();
    }

    protected override void RunPerFrame()
    {
        if (counter >= frameRate)
        {
            health.TakeDamage(damage, false);
            counter = 0;
        }
        else
        {
            counter++;
        }
    }
}
