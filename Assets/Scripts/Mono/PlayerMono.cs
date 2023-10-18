using Unity.Entities;
using UnityEngine;

public class PlayerMono : MonoBehaviour
{
    public float speed;
}
public class PlayerBaker : Baker<PlayerMono>
{
    public override void Bake(PlayerMono authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent<PlayerTag>(entity);
        AddComponent<PlayerMoveInput>(entity);

        AddComponent(entity, new PlayerMoveSpeed
        {
            Value = authoring.speed
        });
    }
}