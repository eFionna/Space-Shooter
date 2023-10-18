using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class DamgeMono : MonoBehaviour
{
    public int Damage = 5;
}
public class DamageBacker : Baker<DamgeMono>
{
    public override void Bake(DamgeMono damgeMono)
    {
        var entity = GetEntity(TransformUsageFlags.None);

        AddComponent(entity, new DamageProperties { Value = damgeMono.Damage });
    }
}