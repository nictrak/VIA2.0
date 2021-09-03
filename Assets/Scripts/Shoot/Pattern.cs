using UnityEngine;

[CreateAssetMenu(fileName = "New Pattern", menuName = "VIA2.0/Pattern", order = 1)]
public class Pattern : ScriptableObject
{

    [SerializeField]
    private Vector2[] patterns;

    public int Length {
        get { return patterns.Length; }
    }

    public Vector2 GetPositionByIndex(int i){
        return patterns[i];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
