using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct ExplosionSpawningsystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<BoomTime>();
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
        bool delete = false;
        foreach(var (firework, localToWorld, localTransform) in SystemAPI.Query<FireworkAspect, LocalToWorld, LocalTransform>().WithAll<BoomTime>()){
            NativeArray<Entity> entities= state.EntityManager.Instantiate(firework.ExplosionPrefab, firework.Amount, Allocator.TempJob);
            foreach (Entity entity in entities)
            {
                state.EntityManager.AddComponentData(entity, new LocalTransform{
                    Position = localToWorld.Position,
                    Rotation = quaternion.identity,
                    Scale = localTransform.Scale
                });
            }
            entities.Dispose(); 
            delete = true;
            
        }
        if(delete){
            var DestroyEntity = new DestroyEntity{
                ECB = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)
            };
            DestroyEntity.Schedule();
        }
    }
}
[BurstCompile]
public partial struct DestroyEntity : IJobEntity
{
    public EntityCommandBuffer ECB;

    public void Execute(Entity entity)
    {
        ECB.DestroyEntity(entity);
    } //Wrongly set up.
}
