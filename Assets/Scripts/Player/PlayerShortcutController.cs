using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShortcutController : MonoBehaviour
{

    public static event Action<int> OnShortcutKeyPress;
    public static event Action<bool> OnShortcutUsed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnShortcutKeyPress?.Invoke(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnShortcutKeyPress?.Invoke(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnShortcutKeyPress?.Invoke(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            OnShortcutKeyPress?.Invoke(3);
        }

        if(Input.GetMouseButtonDown(0))
        {
            OnShortcutUsed?.Invoke(true);
        }
        if(Input.GetMouseButtonDown(1))
        {
            OnShortcutUsed?.Invoke(false);
        }
    }



}
