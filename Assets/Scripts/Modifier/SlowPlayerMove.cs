using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayerMove : Modifier
{
    [SerializeField]
    private float speedModifier;

    private bool lastIsEnable;
    private PlayerMoveController playerMoveController;
    protected override void RunPerFrame()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        IsEnable = false;
        lastIsEnable = false;
        playerMoveController = GetComponentInParent<PlayerMoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        TimeCounterPerFrame();
        if (IsEnable == true && lastIsEnable == false)
        {
            //add mod
            playerMoveController.MoveSpeedModifiers.Add(speedModifier);
        }
        if (IsEnable == false && lastIsEnable == true)
        {
            //remove mod
            playerMoveController.MoveSpeedModifiers.Remove(speedModifier);
        }
        lastIsEnable = IsEnable;
    }
}
