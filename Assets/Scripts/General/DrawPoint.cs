using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.05f);
    }
}
