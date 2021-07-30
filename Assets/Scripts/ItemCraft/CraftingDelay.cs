using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingDelay : MonoBehaviour
{
    [SerializeField]
    private int delayFrame;
    private int currentCounter;
    private string resultName;
    private GameObject resultPrefab;
    // Start is called before the first frame update
    void Start()
    {
        currentCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(currentCounter >= delayFrame) {
            GameObject spawned = Instantiate(resultPrefab);
            spawned.transform.position = transform.position;
            Destroy(gameObject);
        }
        else
        {
            currentCounter++;
        }
    }
    public void SetupResult(string resultName, GameObject resultPrefab)
    {
        this.resultName = resultName;
        this.resultPrefab = resultPrefab;
        GetComponent<CraftingMaterial>().AlternateName = resultName;
    }
}
