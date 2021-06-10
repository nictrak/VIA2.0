using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSpawnAttack : MonoBehaviour, SpecialAttack
{
    [SerializeField]
    private NeedTarget bulletPrefab;
    [SerializeField]
    private float bulletVelocity;

    private PlayerMoveController playerMoveController;
    public void DoSpecial()
    {
        NeedTarget spawned = Instantiate<NeedTarget>(bulletPrefab);
        spawned.SetTarget(transform.position, (Vector2)transform.position + playerMoveController.LastestNonZeroMoveDirection, bulletVelocity);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMoveController = GetComponentInParent<PlayerMoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
