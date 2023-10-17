using Unity.Entities;
using UnityEngine;

public class AsteroidMono : MonoBehaviour
{
    public float Speed;
}

public class AsteroidBaker : Baker<AsteroidMono>
{
    public override void Bake(AsteroidMono authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new AstriodMoveProperties
        {
            Speed = authoring.Speed
        });
    }
}
