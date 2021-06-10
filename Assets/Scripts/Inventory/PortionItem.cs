using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Portion Item", menuName = "VIA2.0/Portion Item", order = 0)]
public class PortionItem : Item
{
    public List<Modifier> playerModifiersPrefab;
    public List<Modifier> weaponModifiersPrefab;
}
