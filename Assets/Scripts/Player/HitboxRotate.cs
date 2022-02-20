using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxRotate : MonoBehaviour
{
    private PlayerMoveController playerMoveController;
    // Start is called before the first frame update
    void Start()
    {
        playerMoveController = GetComponentInParent<PlayerMoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Active HitboxRotate");
        Vector2 direction = playerMoveController.LastestNonZeroMoveDirection;
        Quaternion target = Quaternion.Euler(0, 0, CalAngle(direction));
        transform.rotation = target;
    }
    private float CalAngle(Vector2 direction)
    {
        float res = Vector2.Angle(direction, new Vector2(0, -1));
        if(direction.x < 0)
        {
            res = res * -1;
        }
        return res;
    }
}
