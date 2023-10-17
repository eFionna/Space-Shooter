using Unity.Burst;
using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct SpawnAstriodsSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SpaceProperties>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;
        var spaceEntity = SystemAPI.GetSingletonEntity<SpaceProperties>();
        SpaceAspect asp = SystemAPI.GetAspect<SpaceAspect>(spaceEntity);

        var ecb = new EntityCommandBuffer(Allocator.Temp);

        for (int i = 0; i < asp.AsteroidsToSpawn; i++)
        {
            var astroid = ecb.Instantiate(asp.GetRandomAstroidPrefab());
            var newTransform = asp.GetRandomPosition();
            var rot = asp.GetRandomRotation();

            ecb.SetComponent(astroid, new LocalTransform { Position = newTransform,Scale = 1.0f,Rotation = rot });
        }
        ecb.Playback(state.EntityManager);
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }
}
