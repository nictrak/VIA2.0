﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlipToPlayer : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private AIDestinationSetter destinationSetter;
    private bool isReverse;

    public bool IsReverse { get => isReverse; set => isReverse = value; }

    // Start is called before the first frame update
    void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(destinationSetter.target != null)
        {
            if(destinationSetter.target.transform.position.x < transform.position.x)
            {
                if (isReverse) spriteRenderer.flipX = false;
                else spriteRenderer.flipX = true;
            }
            else
            {
                if (isReverse) spriteRenderer.flipX = true;
                else spriteRenderer.flipX = false;
            }
        }
    }
}
