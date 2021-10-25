using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DamageTextFactory : MonoBehaviour
{
    [SerializeField]
    private RectTransform damageTextPrefab;
    [SerializeField]
    private Vector3 originTranslate;
    [SerializeField]
    private float randomRange;

    private static RectTransform damageTextPrefabStatic;
    private static Transform transformStatic;
    private static Vector3 originTranslateStatic;
    private static float randomRangeStatic;
    // Start is called before the first frame update
    void Start()
    {
        damageTextPrefabStatic = damageTextPrefab;
        transformStatic = transform;
        originTranslateStatic = originTranslate;
        randomRangeStatic = randomRange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void InstantiateDamageText(Vector3 position,int damage, DamageSystem.DamageSubType damageType, Color textColor)
    {
        Camera cam = Resources.FindObjectsOfTypeAll<CameraFollow>()[0].GetComponent<Camera>();
        Vector3 screenPos = cam.WorldToScreenPoint(RandomSpawnPoint(position));
        RectTransform spawned = Instantiate(damageTextPrefabStatic);
        spawned.transform.SetParent(transformStatic);
        spawned.anchoredPosition = screenPos;
        Text text = spawned.GetComponent<Text>();
        text.color = textColor;
        text.text = damageType.ToString() + " " + damage.ToString();
    }
    private static Vector3 RandomSpawnPoint(Vector3 rawPosition)
    {
        Vector3 res = rawPosition + originTranslateStatic + new Vector3(Random.Range(0, randomRangeStatic), Random.Range(0, randomRangeStatic), 0);
        return res;
    }
}
