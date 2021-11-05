using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShot : Modifier
{
    [SerializeField]
    private int damagePoint;
    private Health health;
    
    private bool lastIsEnable;
    
    protected override void RunPerFrame()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        IsEnable = false;
        lastIsEnable = false;
        health = GetComponentInParent<Health>();
    }

    // Update is called once per frame0
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        TimeCounterPerFrame();
        if (IsEnable == true && lastIsEnable == false)
        {
            //add mod
            if(health != null)
            health.TakeDamage(damagePoint, transform.position, false);
        }
        lastIsEnable = IsEnable;
    }
}
