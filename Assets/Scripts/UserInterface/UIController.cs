﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if( HudController.IsUsed || DialogueController.IsShow || PlayerBuildController.current.IsCarryingBlock() ) {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        } else {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
    }
}