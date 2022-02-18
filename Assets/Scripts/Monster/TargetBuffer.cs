using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBuffer : MonoBehaviour
{
    private GameObject instantiatedObject;

    public void Aim(GameObject aimPrefab, Vector2 position){
        instantiatedObject = Instantiate(aimPrefab);
        instantiatedObject.transform.position = position;   
    }

    public Vector2 AimPosition(){
        if(instantiatedObject != null){
            return instantiatedObject.transform.position;
        }
        return this.transform.position;
    }

    public Vector2 CancleAim(){
        Vector2 position = this.transform.position;
        if(instantiatedObject != null) {
            position = instantiatedObject.transform.position;
            Destroy(instantiatedObject);
            instantiatedObject = null;
        }
        return position;
    }

    public void Fire(GameObject firePrefab){
        if(instantiatedObject != null) {
            Vector2 position = instantiatedObject.transform.position;
            Destroy(instantiatedObject);
            instantiatedObject = Instantiate(firePrefab);
            instantiatedObject.transform.position = position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void AimUpdate()
    {

    }
}
