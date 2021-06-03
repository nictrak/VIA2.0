using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modifier : MonoBehaviour
{
    private string modName;
    public int TimeFrame;
    protected int timeCounter;
    protected bool isEnable;

    public string ModName { get => modName; set => modName = value; }

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
        if (isEnable)
        {
            if (timeCounter >= TimeFrame)
            {
                isEnable = false;
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
        isEnable = true;
    }

}
