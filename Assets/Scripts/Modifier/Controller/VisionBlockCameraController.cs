using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionBlockCameraController : MonoBehaviour
{
    // Start is called before the first frame update  
    [SerializeField]
    private string tagTarget;
    [SerializeField]
    private Camera m_OrthographicCamera;
    
    [SerializeField]
    private int debuffTime;

    [SerializeField]
    private float debuffSize;

     private int debuffTimeInternal;
    private bool isVisionBlock;
    private float baseCameraSize;

    // Start is called before the first frame update
    void Start()
    {
        isVisionBlock = false;
        debuffTimeInternal = debuffTime;
        baseCameraSize = m_OrthographicCamera.orthographicSize ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (debuffTimeInternal == 0){
            isVisionBlock = false ;
            m_OrthographicCamera.orthographicSize = baseCameraSize; 
            debuffTimeInternal = debuffTime;
        }else if(isVisionBlock) {
            debuffTimeInternal -= 1;
        }

    }
    // BEWARE: Range should more than object renderer size.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTarget ){
            m_OrthographicCamera.orthographicSize = (float) debuffSize; 
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == tagTarget){
            isVisionBlock = true;
        } 

        
    }
}
