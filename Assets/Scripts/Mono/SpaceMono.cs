using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpaceMono : MonoBehaviour
{
    public float2 Size;
    public int AsteroidsToSpawn;
    public GameObject[] AstroidPrefabs;
    public uint Seed;
}

public class SpaceBaker : Baker<SpaceMono>
{
    public override void Bake(SpaceMono authoring)
    {
        if (authoring.AstroidPrefabs.Length > 10)
        {
            Debug.LogWarning("AstroidPrefabs is bigger then 10. Will not Bake with bad data.");
            return;
        }
        var entity = GetEntity(TransformUsageFlags.Dynamic);//Why???

        var Buff = AddBuffer<AstroidBuffer>(entity);

        for (int i = 0; i < authoring.AstroidPrefabs.Length; i++)
        {
            Buff.Add(new AstroidBuffer {Value = GetEntity(authoring.AstroidPrefabs[i], TransformUsageFlags.Dynamic) });
        }

        AddComponent(entity,new SpaceProperties
        {
            Size = authoring.Size,
            AsteroidsToSpawn = authoring.AsteroidsToSpawn,
        });
        AddComponent(entity, new SpaceRandom
        {
            Random = Unity.Mathematics.Random.CreateFromIndex(authoring.Seed)
        });
    }
}


