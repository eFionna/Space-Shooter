using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial struct AsteroidMoveSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var deltaTime = SystemAPI.Time.DeltaTime;

        new AsteroidMovekJob
        {
            DeltaTime = deltaTime
        }.ScheduleParallel();
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }
}

[BurstCompile]
public partial struct AsteroidMovekJob : IJobEntity
{
    public float DeltaTime;

    [BurstCompile]
    private void Execute(AsteroidAspect asteroid)
    {
        asteroid.Move(DeltaTime);
    }
}
