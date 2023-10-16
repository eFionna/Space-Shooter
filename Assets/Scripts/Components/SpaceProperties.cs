using Unity.Entities;
using Unity.Mathematics;

public struct SpaceProperties : IComponentData
{
    public float2 Size;
    public int AsteroidsToSpawn;
}

[InternalBufferCapacity(10)]
public struct AstroidBuffer : IBufferElementData
{
    public Entity Value;
}