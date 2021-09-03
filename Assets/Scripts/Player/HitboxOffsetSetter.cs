using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxOffsetSetter : MonoBehaviour
{
    [SerializeField]
    private float offsetX;
    [SerializeField]
    private float offsetY;
    private Collider2D targetCollider;
    private PlayerMoveController playerMoveController;

    // Start is called before the first frame update
    void Start()
    {
        targetCollider = GetComponent<Collider2D>();
        playerMoveController = GetComponentInParent<PlayerMoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        targetCollider.offset = CalOffset();
    }
    private Vector2 CalOffset()
    {
        Vector2 direction = playerMoveController.LastestNonZeroMoveDirection;
        return new Vector2(offsetX * direction.x, offsetY * direction.y);
    }
}
