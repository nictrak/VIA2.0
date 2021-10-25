using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField]
    private TriggerRange triggerRange;
    [SerializeField]
    private GameObject interactionMarkerPrefab;

    private PlayerMoveController playerMoveController;
    private GameObject interactionMarker;
    private Talker currentTalker;
    private bool isTalk;
    // Start is called before the first frame update
    void Start()
    {
        isTalk = false;
        playerMoveController = GetComponent<PlayerMoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTalk) UpdateMarker();
        if (Input.GetKeyDown(KeyCode.F) && currentTalker != null && !isTalk)
        {
            currentTalker.Talk();
            isTalk = true;
            SetMovementControl(false);
        }
        if (Input.GetMouseButtonDown(0) && currentTalker != null && isTalk)
        {
            if (currentTalker.IsClickNext())
            {
                isTalk = currentTalker.NextTalk(0);
                if (!isTalk)
                {
                    SetMovementControl(true);
                }
            }
        }
    }
    // private bool IsMarkerUsed()
    // {
    //     return interactionMarker != null;
    // }
    // private void ShowMarker(Vector3 position)
    // {
    //     if (IsMarkerUsed())
    //     {
    //         interactionMarker.transform.position = position;
    //     }
    //     else
    //     {
    //         interactionMarker = Instantiate(interactionMarkerPrefab);
    //         interactionMarker.transform.position = position;
    //     }
    // }
    // private void ClearMarker()
    // {
    //     if(IsMarkerUsed())
    //     {
    //         Destroy(interactionMarker);
    //         currentTalker = null;
    //     }
    // }
    private void UpdateMarker()
    {
        if (!triggerRange.IsEmpty())
        {
            GameObject nearestObject = triggerRange.CalNearestObject(transform.position);
            currentTalker = nearestObject.GetComponent<Talker>();
            // ShowMarker(nearestObject.transform.position);
        }
        else
        {
            // ClearMarker();
        }
    }
    private void SetMovementControl(bool isActive)
    {
        playerMoveController.CanMove = isActive;
        playerMoveController.CanUpdateMoveDirection = isActive;
        playerMoveController.CanAttack = isActive;
        playerMoveController.CanDash = isActive;
    }
    public void NextDialogueSelectedChoice(int param)
    {
        isTalk = currentTalker.NextTalk(param);
        if (!isTalk)
        {
            SetMovementControl(true);
        }
    }
}
