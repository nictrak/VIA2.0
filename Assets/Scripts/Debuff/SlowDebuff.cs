using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDebuff : MonoBehaviour, Debuff
{

    private float defaultVelocity;

    public string Name {

        get
        {
            return "Slow";
        }

    }

    public bool Finished {

        get
        {
            return false;
        }

    }

    public void Apply(GameObject target)
    {
        if (defaultVelocity == 0)
        {
            defaultVelocity = target.GetComponent<PlayerMoveController>().GetMoveVelocity();
        }
        target.GetComponent<PlayerMoveController>().SetMoveVelocity(0.05f);

    }

    public void RemoveEffect(GameObject target)
    {
        Debug.Log(defaultVelocity);
        target.GetComponent<PlayerMoveController>().SetMoveVelocity(defaultVelocity);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
