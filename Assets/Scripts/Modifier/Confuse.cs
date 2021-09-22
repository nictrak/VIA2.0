using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confuse : Modifier
{
    // [SerializeField]
    // private int healPointPerFrame;
    private FleeController fleeController;
    protected override void RunPerFrame()
    {
        fleeController.IsEnable = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        fleeController = GetComponentInParent<FleeController>();
        //Delete: Debug
        Debug.Log("Debug fleeController");
        Debug.Log(fleeController);
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
