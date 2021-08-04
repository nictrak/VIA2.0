using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConditionalWarp : MonoBehaviour
{
    [SerializeField]
    private string nextLevel;
    [SerializeField]
    private Condition condition;
    [SerializeField]
    private bool IsPassIfTrue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerTarget")
        {
            if (condition.IsPass() == IsPassIfTrue)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}
