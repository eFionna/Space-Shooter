using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct SpaceAspect : IAspect
{
    public readonly Entity entity;

    private readonly RefRW<LocalTransform> transform;
    [ReadOnly] private readonly DynamicBuffer<AstroidBuffer> astroidPrefabBuffer;
    private readonly RefRO<SpaceProperties> spaceProperties;
    private readonly RefRW<SpaceRandom> spaceRandom;


    public float3 Position
    {
        get => transform.ValueRO.Position;
        set => transform.ValueRW.Position = value;
    }
}
