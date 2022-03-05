using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    // [SerializeField]
    // private int damagePointPerFrame;
    [SerializeField]
    private string tagTarget;

    [SerializeField]
    private SpriteRenderer m_SpriteRenderer;

    [SerializeField]
    private GameObject interactionMod;
    
    [SerializeField]
    private int bombDelayFrame;

    private int bombDelayCounter;

    private bool triggerBomb;
    private Color baseColor;
    

    // Start is called before the first frame update
    void Start()
    {
        triggerBomb = false;
        bombDelayFrame = bombDelayFrame +1 ;
        baseColor = m_SpriteRenderer.color;
        interactionMod.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // BEWARE: Range should more than object renderer size.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == tagTarget){
            Debug.Log(collision.gameObject.tag);

            //Set the SpriteRenderer to the Color defined by the Sliders
            m_SpriteRenderer.color = new Color(0, 0, 0,255);
            // collision.gameObject.GetComponentInParent<Health>().TakeDamage(damagePointPerFrame);
            if (bombDelayCounter >= bombDelayFrame){
                interactionMod.SetActive(true);   
            }else{
                bombDelayCounter++;
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTarget)
        {
            interactionMod.SetActive(false);
            m_SpriteRenderer.color = baseColor;
            // Destroy(gameObject);
        }
    }

}
