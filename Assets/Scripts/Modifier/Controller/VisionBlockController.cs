using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionBlockController : MonoBehaviour
{

    [SerializeField]
    private string tagTarget;
    [SerializeField]
    private GameObject visionBlock;
    
    [SerializeField]
    private int debuffTime;

     private int debuffTimeInternal;
    private bool isVisionBlock;

    // Start is called before the first frame update
    void Start()
    {
        isVisionBlock = false;
        debuffTimeInternal = debuffTime;
        visionBlock.SetActive(false);
        // visionBlock.active
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (debuffTimeInternal == 0){
            isVisionBlock = false ;
            visionBlock.SetActive(false);
            debuffTimeInternal = debuffTime;
        }else if(isVisionBlock) {
            debuffTimeInternal -= 1;
        }

    }
    // BEWARE: Range should more than object renderer size.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTarget & !visionBlock.active){
            visionBlock.SetActive(true);   
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if ( collision.gameObject.tag == tagTarget){
            isVisionBlock = true;
        } 

        
    }

}
