using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRange : MonoBehaviour
{
    [SerializeField]
    private string tagTarget;

    private List<GameObject> objs;

    public List<GameObject> Objs { get => objs; set => objs = value; }

    // Start is called before the first frame update
    void Start()
    {
        objs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tagTarget)
        {
            objs.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTarget)
        {
            objs.Remove(collision.gameObject);
        }
    }
    private float CalDistance(int index, Vector3 position)
    {
        return (objs[index].transform.position - position).magnitude;
    }
    public GameObject CalNearestObject(Vector3 position)
    {
        if (IsEmpty()) return null;
        float nearestDistance = CalDistance(0, position);
        GameObject nearestObject = objs[0];
        for(int i = 1; i < objs.Count; i++)
        {
            float newDistance = CalDistance(i, position);
            if(newDistance < nearestDistance)
            {
                nearestDistance = newDistance;
                nearestObject = objs[i];
            }
        }
        return nearestObject;
    }
    public bool IsEmpty()
    {
        return objs.Count == 0;
    }
}

