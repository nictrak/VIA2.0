using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHitRotation : MonoBehaviour
{
    private MonsterStateMachine monsterStateMachine;
    // Start is called before the first frame update
    void Start()
    {
        monsterStateMachine = GetComponentInParent<MonsterStateMachine>();
        // Debug.Log(monsterStateMachine.LastestNonZeroMoveDirection);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Active MonsterHitRotation");
        if (MonsterStateMachine.MonsterState.Attack != monsterStateMachine.CurrentState) {
            Vector2 direction = monsterStateMachine.LastestNonZeroMoveDirection;
            Quaternion target = Quaternion.Euler(0, 0, CalAngle(direction));
            transform.rotation = target;
        }

        // Debug.Log(monsterStateMachine.LastestNonZeroMoveDirection);
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
