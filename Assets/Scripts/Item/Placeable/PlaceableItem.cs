using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Placeable Item", menuName = "VIA2.0/Items/Placeable Item")]
public class PlaceableItem : Item, IShortcutable
{
    [SerializeField]
    private Block placeablePrefab;
    public Block PlaceablePrefab { get => placeablePrefab; }

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
        throw new System.NotImplementedException();
    }

}
