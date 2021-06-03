using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private List<Modifier> modifiersPrefab;

    public List<Modifier> ModifiersPrefab { get => modifiersPrefab; set => modifiersPrefab = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
