using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionIcon : MonoBehaviour
{
    [SerializeField]
    private string tagTarget;

    [SerializeField]
    private float yaxis;

    [SerializeField]
    private GameObject interactionMarkerPrefab;
    // Start is called before the first frame update
    private GameObject interactionMarker;

    private bool trigger;
    private Vector3 position;
    void Start()
    {
        // interactionMarker = gameObject.GetComponent(interactionMarkerPrefab);
        position = gameObject.transform.position + new Vector3(0,yaxis,0);
        trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (trigger){
        //     gameObject.transform.position = position;
        // }
        // Debug.Log(tagTarget);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tagTarget)
        {
            ShowMarker();
            trigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTarget)
        {
            ClearMarker();
            trigger = false;
        }
    }

    private bool IsMarkerUsed()
    {
        return interactionMarker != null;
    }
    private void ShowMarker()
    {
        if (IsMarkerUsed())
        {
            interactionMarker.SetActive(true); 
            interactionMarker.transform.position = position;
        }
        else
        {
            interactionMarker = Instantiate(interactionMarkerPrefab);
            interactionMarker.transform.position = position;
        }
    }
    private void ClearMarker()
    {
        if(IsMarkerUsed())
        {
            // Destroy(interactionMarkerPrefab);
            interactionMarker.SetActive(false); 

            // DestroyImmediate(interactionMarkerPrefab, true);
        }
    }
}
