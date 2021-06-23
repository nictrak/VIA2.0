using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject followed;
    public Vector3 translate;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(followed == null)
        {
            followed = GameObject.FindGameObjectWithTag("Player");
        }
    }
    private void LateUpdate()
    {
        if(followed != null) transform.position = followed.transform.position + translate;
    }
}
