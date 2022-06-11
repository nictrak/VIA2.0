using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildController : MonoBehaviour
{
    public static PlayerBuildController current;

    [SerializeField]
    private CarryingBlock carryingBlock;

    public CarryingBlock CarryingBlock { get => carryingBlock; }

    [SerializeField]
    private Block blockPrefab;

    [SerializeField]
    private SpriteRenderer blockSpriteRenderer;

    [SerializeField]
    private GameObject carryBlockObject;

    private static Color normalColor = new Color(1f,1f,1f,0.5f);
    private static Color disableColor = Color.clear;

    private void Awake() {
        current = this;
    }

    private void Update() {
        if(carryingBlock.Item != null) {
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            carryBlockObject.transform.position = mousePosition;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        carryingBlock = carryBlockObject.GetComponent<CarryingBlock>();
    }

    public void ChangeHoldingItem(PlaceableItem newBlock) {
        if (IsCarryingBlock())
        {
            carryBlockObject.SetActive(false);
            carryingBlock.Item = null;
        }
        if(newBlock != null)
        {
            blockSpriteRenderer.color = normalColor;
            blockSpriteRenderer.sprite = newBlock.Icon;
            carryBlockObject.SetActive(true);
            carryingBlock.Item = newBlock;
        } else {
            blockSpriteRenderer.color = disableColor;
        }
    }

    public bool IsCarryingBlock(){
        return carryingBlock.Item != null;
    }

    public bool PlaceBlock(){

        if(carryingBlock.CanPlace()){
            Block spawnedBlock = Instantiate(blockPrefab);
            spawnedBlock.transform.position = carryBlockObject.transform.position;
            spawnedBlock.Item = carryingBlock.Item;
            return true;
        }
        return false;
        
    }

}