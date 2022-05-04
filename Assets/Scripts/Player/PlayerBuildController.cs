using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildController : MonoBehaviour
{
    public static PlayerBuildController current;

    [SerializeField]
    private Block block;

    public Block Block { get => block; }

    private void Awake() {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeHoldingItem(Block newBlock) {
        if (IsCarryingBlock())
        {
            Destroy(block.gameObject);
            block = null;
        }
        if(newBlock != null)
        {
            block = Instantiate<Block>(newBlock, transform);
        }
    }

    public bool IsCarryingBlock(){
        return block != null;
    }
}