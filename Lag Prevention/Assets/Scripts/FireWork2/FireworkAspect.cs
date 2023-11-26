using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
public readonly partial struct FireworkAspect : IAspect
{
    readonly RefRO<LocalTransform> localTransform;
    readonly RefRO<FireworkEnd> fireWorkEnd;
    public int Amount => fireWorkEnd.ValueRO.Amount;
    public Entity ExplosionPrefab => fireWorkEnd.ValueRO.explosionPrefab;
}
/*
readonly RefRO<LocalTransform> localTransform;
    readonly RefRO<ExplosionDistance> explosionDistance;
    readonly float ActualDistance => localTransform.ValueRO.Position.z + explosionDistance.ValueRO.distance;
    readonly float ActualHeight => localTransform.ValueRO.Position.y + explosionDistance.ValueRO.height;
*/
