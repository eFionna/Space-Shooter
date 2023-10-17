using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct SpaceAspect : IAspect
{
    public readonly Entity entity;

    private readonly RefRO<LocalTransform> transform;
    [ReadOnly] private readonly DynamicBuffer<AstroidBuffer> astroidPrefabBuffer;
    private readonly RefRO<SpaceProperties> spaceProperties;
    private readonly RefRW<SpaceRandom> spaceRandom;

    public float3 Position => transform.ValueRO.Position;

    public int AsteroidsToSpawn => spaceProperties.ValueRO.AsteroidsToSpawn;

    public Entity GetRandomAstroidPrefab()
    {
        int randomVal = spaceRandom.ValueRW.Random.NextInt(astroidPrefabBuffer.Length);
        return astroidPrefabBuffer[randomVal].Value;
    }

    public quaternion GetRandomRotation() => quaternion.RotateZ(spaceRandom.ValueRW.Random.NextFloat(360.0f));
    public float3 GetRandomPosition() => spaceRandom.ValueRW.Random.NextFloat3(MinCorner, MaxCorner);


    private float3 MinCorner => transform.ValueRO.Position - HalfDimensions;
    private float3 MaxCorner => transform.ValueRO.Position + HalfDimensions;
    private float3 HalfDimensions => new()
    {
        x = spaceProperties.ValueRO.Size.x * 0.5f,
        y = spaceProperties.ValueRO.Size.y * 0.5f,
        z = 0
    };
}
