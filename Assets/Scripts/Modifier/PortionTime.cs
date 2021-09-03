using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortionTime : MonoBehaviour
{
    [SerializeField]
    private int timeFrame;
    [SerializeField]
    private string portionName;
    [SerializeField]
    private Color gizmosColor;

    [SerializeField]
    private int timeCounter;

    public string PortionName { get => portionName; set => portionName = value; }
    public int TimeFrame { get => timeFrame; set => timeFrame = value; }

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(timeCounter > timeFrame)
        {
            Destroy(gameObject);
        }else
        {
            timeCounter++;
        }
    }
    public void ResetTime(int time)
    {
        timeFrame = time;
        timeCounter = 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawWireSphere(transform.position, ((float)timeCounter - (float)timeFrame) / (float)timeFrame);
    }
}
