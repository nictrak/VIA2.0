using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform transform;
    private float delay = 0;
    private float pastime = 0;
    private float when = 1.0f;
    private float Frame_high = 0.50f;
    private float Frame_low = 0f;
    private Vector3 off;
    private Vector3 upY;
    private Vector3 base_position;
    
    void Start()
    {
        off = new Vector3(Random.Range(-2,2),Random.Range(-2,2) , 0);
        upY = new Vector3(0,0.1f,0);
    }


    // Update is called once per frame
    void Update()
    {
        if (when >= delay)
        {
            pastime = Time.deltaTime;
            transform.position += off * Time.deltaTime;
            delay += pastime;
            base_position = transform.position;
        } else 
        {
            if ( Frame_high >= Frame_low)
            {
                pastime = Time.deltaTime;
                transform.position += upY * Time.deltaTime;
                Frame_low += pastime;
            }else  {
                transform.position = base_position;
                Frame_low = 0f;
            }
        }
        
    }
}
