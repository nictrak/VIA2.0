using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterToken {
    public float timeLeft;
    public bool reserved;

    public MonsterToken()
    {
        timeLeft = 0.0f;
        reserved = false;
    }
}
public class MonsterTokenController : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField]
    private int tokenAmount = 9;
    [SerializeField]
    private float delayTime = 30.0f;
    private MonsterToken[] tokens;

    public bool RequestToken(){
        if(useToken()){
            return true;
        } else {
            return false;
        }
    }

    private bool useToken(){
        foreach (MonsterToken token in tokens){
            if(!token.reserved){
                token.timeLeft = delayTime;
                token.reserved = true;
                return true;
            }
        }
        return false;
    }
    void Start()
    {
        tokens = new MonsterToken[tokenAmount];
        for(int i = 0; i < tokenAmount; i++) {
            tokens[i] = new MonsterToken();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (MonsterToken token in tokens){
            if(token.reserved){
                token.timeLeft -= Time.deltaTime;
                if(token.timeLeft <= 0f){
                    token.reserved = false;
                }
            }
        };
    }

}
