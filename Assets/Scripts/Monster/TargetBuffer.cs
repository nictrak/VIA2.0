using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBuffer : MonoBehaviour
{
    private Vector2 targetPosition;
    private bool isAim;
    private GameObject currentAim;
    [SerializeField]
    private GameObject aimPrefab;

    public Vector2 TargetPosition { get => targetPosition; set => targetPosition = value; }
    public bool IsAim { get => isAim; set => isAim = value; }

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector2();
        isAim = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (aimPrefab != null) AimUpdate();
    }
    private void AimUpdate()
    {
        if (isAim)
        {
            if(currentAim == null)
            {
                currentAim = Instantiate(aimPrefab);
                currentAim.transform.position = targetPosition;
            }
        }
        else
        {
            if(currentAim != null)
            {
                Destroy(currentAim);
                currentAim = null;
            }
        }
    }
}
