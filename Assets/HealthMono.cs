using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class HealthMono : MonoBehaviour
{
    public int Helth = 100;
    public int DamageResistance = 1;
}



public class HealthBaker : Baker<HealthMono>
{
    public override void Bake(HealthMono authoring)
    {
        var entity = GetEntity(TransformUsageFlags.None);

        AddComponent(entity, new HealthPropertise { DamageResistance = authoring.DamageResistance, Helth = authoring.Helth });
        AddComponent<DefenderTag>(entity);
    }
}

