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
    private int tokenAmount;
    [SerializeField]
    private float delayTime = 30.0f;
    private MonsterToken[] monsterTokens;
    private MonsterToken[] alliesTokens;

    public bool RequestToken(bool isEnemy = true){
        if(useToken(isEnemy)){
            return true;
        } else {
            return false;
        }
    }

    private bool useToken(bool isEnemy){
        if(isEnemy) {
            foreach (MonsterToken token in monsterTokens){
                if(!token.reserved){
                    token.timeLeft = delayTime;
                    token.reserved = true;
                    return true;
                }
            }
            return false;
        } else {
            foreach (MonsterToken token in alliesTokens){
                if(!token.reserved){
                    token.timeLeft = delayTime;
                    token.reserved = true;
                    return true;
                }
            }
            return false;
        }
    }
    void Start()
    {
        monsterTokens = new MonsterToken[tokenAmount];
        alliesTokens = new MonsterToken[tokenAmount];
        for(int i = 0; i < tokenAmount; i++) {
            monsterTokens[i] = new MonsterToken();
            alliesTokens[i] = new MonsterToken();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (MonsterToken token in monsterTokens){
            if(token.reserved){
                token.timeLeft -= Time.deltaTime;
                if(token.timeLeft <= 0f){
                    token.reserved = false;
                }
            }
        };

        foreach (MonsterToken token in alliesTokens){
            if(token.reserved){
                token.timeLeft -= Time.deltaTime;
                if(token.timeLeft <= 0f){
                    token.reserved = false;
                }
            }
        };

    }

}
