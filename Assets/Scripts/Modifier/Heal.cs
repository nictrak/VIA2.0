using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Modifier
{
    [SerializeField]
    private int healPointPerFrame;
    private Health health;
    protected override void RunPerFrame()
    {
        health.Heal(healPointPerFrame);
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
