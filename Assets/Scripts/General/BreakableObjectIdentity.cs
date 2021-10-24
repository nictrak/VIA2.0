using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjectIdentity : MonoBehaviour
{
    private Health health;
    [SerializeField]
    private GameObject mainObject;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.IsDead == true)
        {
            Destroy(mainObject);
        }
    }
}
