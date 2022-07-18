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
    private GameObject carryBlockObject;

    [SerializeField]
    private Grid grid;

    private Vector2 spherePos = Vector2.zero;
    private float sphereSize = 0f;
    private Vector2 spherePos2 = Vector2.zero;
    private float sphereSize2 = 0f;

    private static Color normalColor = new Color(1f,1f,1f,0.5f);
    private static Color disableColor = Color.clear;

    private void Awake() {
        current = this;
        if (grid == null) {
            grid = Grid.FindObjectOfType<Grid>();
        }
    }

    private void Update() {
        if(carryingBlock.Item != null) {

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)){

                Vector3Int cellPos = grid.WorldToCell(mousePosition);
                mousePosition = (Vector2)grid.CellToWorld(cellPos) + Vector2.up*grid.cellSize.y/2;

            }
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
            carryBlockObject.SetActive(true);
            carryingBlock.SetColor(normalColor);
            carryingBlock.Item = newBlock;
        } else {
            carryingBlock.SetColor(disableColor);
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