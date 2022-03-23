using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    // [SerializeField]
    // private int damagePointPerFrame;
    // [SerializeField]
    [SerializeField]
    private string tagTarget;

    [SerializeField]
    private SpriteRenderer m_SpriteRenderer;

    [SerializeField]
    private GameObject interactionMod;
    
    [SerializeField]
    private int bombDelayFrame;

    [SerializeField]
    private Animator anim;



    private int bombDelayCounter;

    private bool triggerBomb;
    private Color baseColor;
    

    // Start is called before the first frame update
    void Start()
    {
        triggerBomb = false;
        bombDelayFrame = bombDelayFrame +1 ;
        m_SpriteRenderer.sprite = null ;
        interactionMod.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // BEWARE: Range should more than object renderer size.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == tagTarget && !triggerBomb){
            Debug.Log(collision.gameObject.tag);
            // anim.Play("trap-mine-trigger");
            //Set the SpriteRenderer to the Color defined by the Sliders
            // m_SpriteRenderer.color = new Color(0, 0, 0,255);
            // collision.gameObject.GetComponentInParent<Health>().TakeDamage(damagePointPerFrame);
            interactionMod.SetActive(true);   
            triggerBomb = true;
            
        } 
        if (triggerBomb) {
            if (bombDelayCounter >= bombDelayFrame){
                triggerBomb = false;
                anim.Play("trap-mine-bomb");
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
            // m_SpriteRenderer.sprite = null ;
            // Destroy(gameObject);
        }
    }

}
