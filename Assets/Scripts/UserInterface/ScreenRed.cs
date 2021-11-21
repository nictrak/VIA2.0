using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenRed : MonoBehaviour
{
    [SerializeField]
    private float alphaChangeRateFadeIn;
    [SerializeField]
    private float alphaChangeRateFadeOut;

    private Image image;

    private static bool isDamage;
    private static bool isAlreadyRed;
    private static float currentAlpha;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        isDamage = false;
        currentAlpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (isDamage)
        {
            if (isAlreadyRed)
            {
                //FadeOut
                if (FadeOut()) isDamage = false;
            }
            else
            {
                //FadeIn
                if (FadeIn()) isDamage = isAlreadyRed = true;
            }
        }
    }

    private bool FadeOut() //return if hit 0
    {
        currentAlpha = currentAlpha - alphaChangeRateFadeOut;
        if(currentAlpha <= 0)
        {
            currentAlpha = 0;
            image.color = new Color(1, 1, 1, currentAlpha);
            return true;
        }
        image.color = new Color(1, 1, 1, currentAlpha);
        return false;
    }
    private bool FadeIn() //return if hit 0
    {
        currentAlpha = currentAlpha + alphaChangeRateFadeIn;
        if (currentAlpha >= 1)
        {
            currentAlpha = 1;
            image.color = new Color(1, 1, 1, currentAlpha);
            return true;
        }
        image.color = new Color(1, 1, 1, currentAlpha);
        return false;
    }
    public static void StartDamage()
    {
        isDamage = true;
        isAlreadyRed = false;
        currentAlpha = 0;
    }
}
