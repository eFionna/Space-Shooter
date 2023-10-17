using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct AsteroidAspect : IAspect
{
    public readonly Entity entity;

    private readonly RefRW<LocalTransform> transform;
    private readonly RefRO<AstriodMoveProperties> astriodMoveProperties;

    private float Speed => astriodMoveProperties.ValueRO.Speed;

    private float3 Position
    {
        get => transform.ValueRO.Position;
        set => transform.ValueRW.Position = value;
    }

    public void Move(float deltaTime)
    {
        Position += transform.ValueRO.Up() * Speed * deltaTime;
    }
}
