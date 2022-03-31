using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackEffectInput
{
    public bool DoHurt = true;
    public GameObject HitEffectPrefab;

    public AttackEffectInput(bool doHurt, GameObject hitEffectPrefab){
        DoHurt = doHurt;
        HitEffectPrefab = hitEffectPrefab;
    }

    public AttackEffectInput(bool doHurt){
        DoHurt = doHurt;
        HitEffectPrefab = null;
    }

    public AttackEffectInput(GameObject hitEffectPrefab){
        DoHurt = true;
        HitEffectPrefab = hitEffectPrefab;
    }

    public AttackEffectInput(){
        DoHurt = true;
        HitEffectPrefab = null;
    }
}

public class KnockbackInput
{
    public Vector2 DamageDirection;
    public float KnockBackPower;

    public KnockbackInput(Vector2 damageDirection, float knockBackPower){
        KnockBackPower = knockBackPower;
        DamageDirection = damageDirection;
    }
}

public class DamageInput
{
    public int Damage;
    public DamageSystem.DamageSubType DamageSubType;

    public DamageInput(int damage){
        this.Damage = damage;
        this.DamageSubType = DamageSystem.DamageSubType.Pure;
    }

    public DamageInput(int damage, DamageSystem.DamageSubType damageSubType){
        this.Damage = damage;
        this.DamageSubType = damageSubType;
    }
}