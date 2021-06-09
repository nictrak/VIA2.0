using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockController : MonoBehaviour
{
    private bool isKnocked;
    private Vector2 knockedVector;
    private int knockedFrame;
    private int knockCounter;

    public bool IsKnocked { get => isKnocked; set => isKnocked = value; }
    public Vector2 KnockedVector { get => knockedVector; set => knockedVector = value; }

    // Start is called before the first frame update
    void Start()
    {
        isKnocked = false;
        knockCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (isKnocked)
        {
            if (knockCounter >= knockedFrame)
            {
                isKnocked = false;
                knockCounter = 0;
            }
            else
            {
                knockCounter++;
            }
        }
    }
    public void StartKnock(Vector3 knockerPosition, float knockVelocity, int knockFrame)
    {
        Vector2 direction = (transform.position - knockerPosition).normalized;
        knockedVector = direction * knockVelocity;
        knockedFrame = knockFrame;
        isKnocked = true;
    }
}
