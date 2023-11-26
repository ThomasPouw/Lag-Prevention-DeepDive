using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct  FireWorkLauncherSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
        var fireWorkJob = new FireworkMoveJob
        {
            ECB = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged),
            DeltaTime = SystemAPI.Time.DeltaTime
        };
        fireWorkJob.Schedule();
    }
}
[BurstCompile]
public partial struct FireworkMoveJob: IJobEntity
{
    public EntityCommandBuffer ECB;
    public float DeltaTime;

    void Execute(Entity entity, ref LocalTransform transform,  ref FireworkSpeed fireworkSpeed, ref FireworkMaxHeight fireworkMaxHeight)
    {
         transform.Position += (transform.Up() * fireworkSpeed.speed * DeltaTime);
        if(transform.Position.y > fireworkMaxHeight.maxHeight){

            //Actually delete and put explosion here
            ECB.AddComponent<BoomTime>(entity);
        }
       
    }
}
