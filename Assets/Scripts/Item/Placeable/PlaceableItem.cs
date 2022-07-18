using UnityEngine;

[CreateAssetMenu(fileName = "New Placeable Item", menuName = "VIA2.0/Items/Placeable Item")]
public class PlaceableItem : Item, IShortcutable
{
    public Sprite[] Icons;

    [SerializeField]
    private Vector2 size;

    public Vector2 Size {
        get { return size; }
    }

    public override Item Copy() {
        return Instantiate(this);
    }

    public override void Destroy() {
        Destroy(this);
    }

    public bool CanUse()
    {
        return true;
    }

    public int Use(bool isRightClick)
    {
        if(PlayerMoveController.current.BlockUsedHandler(isRightClick)){
            return 1;
        }
        return 0;
    }

}
