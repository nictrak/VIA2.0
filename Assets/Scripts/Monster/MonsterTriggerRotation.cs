using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MonsterTriggerRotation : MonoBehaviour
{
    [SerializeField]
    private AIDestinationSetter aIDestinationSetter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (aIDestinationSetter.target.transform.position - transform.position).normalized;
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
