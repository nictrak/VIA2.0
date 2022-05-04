
public class EquipmentSlot : SpecificItemSlot<EquippableItem>
{

    public EquipmentType EquipmentType;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = EquipmentType.ToString() + " Slot";
    }

    protected override bool checkItem(Item item)
    {
        return base.checkItem(item) && ((EquippableItem)item).EquipmentType == EquipmentType;
    }

}
