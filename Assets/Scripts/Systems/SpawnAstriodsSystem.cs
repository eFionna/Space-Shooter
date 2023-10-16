using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
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
        Debug.Log(asp);
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }
}
