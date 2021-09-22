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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (IsEnable) RunPerFrame();
        if (!IsEnable) ClearConfuse();
        TimeCounterPerFrame();
    }

    // Debug : Nagate Status Confuse
    private  void ClearConfuse()
    {
        fleeController.IsEnable = false;
        // Due to Affect of Mother-Object destroy not Destroy internal script of prefab
        Destroy(this);
    }

}
