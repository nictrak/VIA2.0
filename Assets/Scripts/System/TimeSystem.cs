using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    public float slowdownFactor;
    private bool isSlow;
    // Start is called before the first frame update
    void Start()
    {
        isSlow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (!isSlow)
            {
                DoSlowMotion();
            }
        }
        else
        {
            if (isSlow)
            {
                DoStandardTime();
            }
        }
    }
    public void DoSlowMotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        isSlow = true;
    }
    public void DoStandardTime()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        isSlow = false;
    }
}
