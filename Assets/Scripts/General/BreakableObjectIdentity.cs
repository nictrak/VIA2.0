using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjectIdentity : MonoBehaviour
{
    [SerializeField]
    private GameObject mainObject;
    [SerializeField]
    private SpriteRenderer rendererObject;
    [SerializeField]
    private float alphaDecreasePerFrame;

    private Health health;
    private Color alphaDecreaseColor;
    private bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        alphaDecreaseColor = new Color(0, 0, 0, alphaDecreasePerFrame);
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(health.IsDead == true)
        {
            isStart = true;
        }
        if (isStart)
        {
            rendererObject.color = rendererObject.color - alphaDecreaseColor;
            if(rendererObject.color.a <= 0)
            {
                Destroy(mainObject);
            }
        }
    }
}
