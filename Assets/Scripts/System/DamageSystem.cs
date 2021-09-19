using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem
{
    public enum DamageMainType
    {
        Physical,
        Magic,
        Pure
    }
    public enum DamageSubType
    {
        Chop, //0
        Strike, //1
        Pierce, //2
        Void, //3
        Electric, //4
        Fire, //5
        Frost, //6
        Pure //7
    }

    public static DamageMainType GetMainType(DamageSubType subType) 
    { 
        if((int)subType <= 2)
        {
            return DamageMainType.Physical;
        }
        else if((int)subType <= 6)
        {
            return DamageMainType.Magic;
        }
        else return DamageMainType.Pure;
    }
}
