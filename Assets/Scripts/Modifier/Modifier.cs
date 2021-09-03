using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modifier : MonoBehaviour
{
    public string ModName;
    public int TimeFrame;
    protected int timeCounter;
    public bool IsEnable;
    public Color GizmosColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected abstract void RunPerFrame();

    protected void TimeCounterPerFrame()
    {
        if (IsEnable)
        {
            if (timeCounter >= TimeFrame)
            {
                IsEnable = false;
                timeCounter = 0;
            }
            else
            {
                timeCounter++;
            }
        }
    }
    public void ResetTime(int newTime)
    {
        TimeFrame = newTime;
        timeCounter = 0;
        IsEnable = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        if (IsEnable) Gizmos.DrawWireSphere(transform.position, ((float)timeCounter - (float)TimeFrame) / (float)TimeFrame);
    }
}
