using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionIcon : MonoBehaviour
{
    [SerializeField]
    private string tagTarget;

    [SerializeField]
    private GameObject interactionMarkerPrefab;
    // Start is called before the first frame update
    private GameObject interactionMarker;
    void Start()
    {
        // interactionMarker = gameObject.GetComponent(interactionMarkerPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tagTarget)
        {
            Debug.Log("PLayer InteractionIcon in");
            Debug.Log(gameObject.transform.position);
            ShowMarker(gameObject.transform.position);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTarget)
        {
            Debug.Log("PLayer InteractionIcon out");
            ClearMarker();
        }
    }

    private bool IsMarkerUsed()
    {
        return interactionMarker != null;
    }
    private void ShowMarker(Vector3 position)
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
