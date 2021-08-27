﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WarpSystem : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void WarpToScene(string sceneName)
    {
        QuestSystem.SendQuestMessage("EscapeFrom " + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName);
        QuestSystem.SendQuestMessage("GoTo " + sceneName);
    }
}
