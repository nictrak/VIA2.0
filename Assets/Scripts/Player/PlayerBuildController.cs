using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildController : MonoBehaviour
{
    public static PlayerBuildController current;

    [SerializeField]
    private Block block;

    public Block Block { get => block; }

    [SerializeField]
    private SpriteRenderer blockSpriteRenderer;

    [SerializeField]
    private GameObject carryBlockObject;

    private static Color normalColor = Color.white;
    private static Color disableColor = Color.clear;

    private void Awake() {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        block = carryBlockObject.GetComponent<Block>();
    }

    public void ChangeHoldingItem(PlaceableItem newBlock) {
        if (IsCarryingBlock())
        {
            carryBlockObject.SetActive(false);
            block.Item = null;
        }
        if(newBlock != null)
        {
            blockSpriteRenderer.color = normalColor;
            blockSpriteRenderer.sprite = newBlock.Icon;
            carryBlockObject.SetActive(true);
            block.Item = newBlock;
        } else {
            blockSpriteRenderer.color = disableColor;
        }
    }

    public bool IsCarryingBlock(){
        return block.Item != null;
    }
}