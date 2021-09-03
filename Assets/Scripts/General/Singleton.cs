using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    [SerializeField]
    private string currentHash;
    [SerializeField]
    private bool isDontDestroyOnLoad;
    private static Dictionary<string, GameObject> singletons;
    // Start is called before the first frame update
    void Start()
    {
        if (singletons == null)
        {
            singletons = new Dictionary<string, GameObject>();
        }
        if (singletons.ContainsKey(currentHash))
        {
            singletons[currentHash].transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
        else
        {
            singletons.Add(currentHash, gameObject);
        }
        if(isDontDestroyOnLoad) DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
