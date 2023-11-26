using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ExplosionAuthoring : MonoBehaviour
{
    public float distance;
    public float height;
    public float time;
}
public struct ExplosionDistance : IComponentData
{
    public float distance;
    public float height;
    
}
public class ExplosionBaker : Baker<ExplosionAuthoring>
{
    public override void Bake(ExplosionAuthoring authoring)
    {
        Unity.Mathematics.Random R = new Unity.Mathematics.Random(123456);
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new ExplosionDistance{
            distance = authoring.distance,
            height = authoring.height
        });
    }
}
