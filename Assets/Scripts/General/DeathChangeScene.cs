using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathChangeScene : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private bool testModeOn;
    [SerializeField]
    private int delayFrame;
    [SerializeField]
    private Vector3 newPosition;
    [SerializeField]
    private GameObject mainObject;

    private Health health;
    private bool isAlreadyDead;
    private int frameCounter;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        isAlreadyDead = false;
        frameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!testModeOn){
            CheckIsAlreadyDead();
            RunAnimationThenChangeSceneIfDead();
        }

    }
    private void CheckIsAlreadyDead()
    {
        if (health.IsDead)
        {
            isAlreadyDead = true;
        }
    }
    private void RunAnimationThenChangeSceneIfDead()
    {
        //TODO add run animation process
        if (isAlreadyDead)
        {
            if(frameCounter >= delayFrame)
            {
                frameCounter = 0;
                mainObject.transform.position = newPosition;
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                frameCounter++;
            }
        }
    }
}
