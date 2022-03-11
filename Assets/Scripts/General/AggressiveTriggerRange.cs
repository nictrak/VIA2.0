using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveTriggerRange : TriggerRange{

    private string subTarget = "";
    private List<GameObject> subObjs;

    public List<GameObject> SubObjs { get => subObjs; set => subObjs = value; }

    protected override void Awake()
    {
        subObjs = new List<GameObject>();
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        if (monsterAttributes != null){
            if(monsterAttributes.monsterType == monsterType.Enemy){
                tagTarget = "PlayerTarget";
                subTarget = "EnemyTarget";
            } else if (monsterAttributes.monsterType == monsterType.Friendly) {
                tagTarget = "EnemyTarget";
                subTarget = "PlayerTarget";
            }
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tagTarget)
        {
            objs.Add(collision.gameObject);
        } else if(collision.gameObject.tag == subTarget) {
            subObjs.Add(collision.gameObject);
        }
    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTarget)
        {
            objs.Remove(collision.gameObject);
        } else if(collision.gameObject.tag == subTarget) {
            subObjs.Add(collision.gameObject);
        }
    }

    public bool IsSubEmpty(){
        return subObjs.Count == 0;
    }

    public bool RemoveSub(GameObject targetObject){
        return subObjs.Remove(targetObject);
    }

    public GameObject PopSub(){
        if(IsSubEmpty()) return null;
        GameObject popObject = subObjs[0];
        subObjs.RemoveAt(0);
        return popObject;
    }
}