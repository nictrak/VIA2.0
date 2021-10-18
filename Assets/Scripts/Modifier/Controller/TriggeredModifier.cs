using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredModifier : MonoBehaviour
{
    [SerializeField]
    private List<Modifier> modifiersPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        ModifierController modCon = collision.GetComponent<ModifierController>();
        if(modCon != null)
        {
            for(int i = 0; i < modifiersPrefab.Count; i++)
            {
                modCon.AddModifier(modifiersPrefab[i]);
            }
        }
    }
}
