using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField]
    private TriggerRange triggerRange;
    [SerializeField]
    private GameObject interactionMarkerPrefab;

    private GameObject interactionMarker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMarker();
    }
    private bool IsMarkerUsed()
    {
        return interactionMarker != null;
    }
    private void ShowMarker(Vector3 position)
    {
        if (IsMarkerUsed())
        {
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
            Destroy(interactionMarker);
        }
    }
    private void UpdateMarker()
    {
        if (!triggerRange.IsEmpty())
        {
            GameObject nearestObject = triggerRange.CalNearestObject(transform.position);
            ShowMarker(nearestObject.transform.position);
        }
        else
        {
            ClearMarker();
        }
    }
}
