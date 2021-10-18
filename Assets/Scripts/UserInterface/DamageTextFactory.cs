using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextFactory : MonoBehaviour
{
    [SerializeField]
    private RectTransform damageTextPrefab;

    private static RectTransform damageTextPrefabStatic;
    private static Transform transformStatic;
    // Start is called before the first frame update
    void Start()
    {
        damageTextPrefabStatic = damageTextPrefab;
        transformStatic = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void InstantiateDamageText(Vector3 position)
    {
        Camera cam = Resources.FindObjectsOfTypeAll<CameraFollow>()[0].GetComponent<Camera>();
        Vector3 screenPos = cam.WorldToScreenPoint(position);
        RectTransform spawned = Instantiate(damageTextPrefabStatic);
        spawned.transform.SetParent(transformStatic);
        spawned.anchoredPosition = screenPos;
    }
}
