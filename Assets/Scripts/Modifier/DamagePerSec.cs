using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePerSec : Modifier
{
    [SerializeField]
    private int damagePointPerFrame;
    private Health health;

    protected override void RunPerFrame()
    {
        health.TakeDamage(damagePointPerFrame, transform.position, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponentInParent<Health>();
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
}
