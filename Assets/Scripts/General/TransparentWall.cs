using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWall : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float transparentShade;
    [SerializeField]
    private TriggerRange transparentRange;
    [SerializeField]
    private float colorFadeRate;
    [SerializeField]
    private float maxShade = 1;
    [SerializeField]
    private float minShade = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transparentShade = 1;
        spriteRenderer.color = GetColorFromShade();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        FadeColorPerFrame();
    }
    private Color GetColorFromShade()
    {
        return new Color(transparentShade, transparentShade, transparentShade, transparentShade);
    }
    private void FadeColorPerFrame()
    {
        if (transparentRange.IsEmpty())
        {
            if(transparentShade < maxShade)
            {
                transparentShade += colorFadeRate;
                if (transparentShade > maxShade) transparentShade = maxShade;
                spriteRenderer.color = GetColorFromShade();
            }
        }
        else
        {
            if (transparentShade > minShade)
            {
                transparentShade -= colorFadeRate;
                if (transparentShade < minShade) transparentShade = minShade;
                spriteRenderer.color = GetColorFromShade();
            }
        }
    }
}
