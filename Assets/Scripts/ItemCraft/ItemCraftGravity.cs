using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCraftGravity : MonoBehaviour
{
    [SerializeField]
    private float gravityVelocity;
    private Rigidbody2D rgbody;
    private TriggerRange triggerRange;
    // Start is called before the first frame update
    void Start()
    {
        triggerRange = GetComponentInChildren<TriggerRange>();
        rgbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
               
    }
    private void FixedUpdate()
    {
        rgbody.MovePosition(rgbody.position + CalMoveVector());
    }
    private Vector2 CalSingleMoveVector(Vector2 otherPosition)
    {
        return (otherPosition - (Vector2)transform.position).normalized * gravityVelocity;
    }
    public Vector2 CalMoveVector()
    {
        Vector2 result = new Vector2();
        for(int i = 0; i < triggerRange.Objs.Count; i++)
        {
            result = result + CalSingleMoveVector(triggerRange.Objs[i].transform.position);
        }
        return result;
    }
}
