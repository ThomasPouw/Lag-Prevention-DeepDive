using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;

public class FireworkAuthoring : MonoBehaviour
{
    public float speed;
    public GameObject explosionPrefab;
    
}
public struct FireworkSpeed : IComponentData
{
    public float speed;
    
}
public struct FireworkMaxHeight : IComponentData
{
    public float maxHeight;
    
}
public struct FireworkEnd : IComponentData{
    public Entity explosionPrefab;
    public int Amount;
}
public struct BoomTime: IComponentData{}

public class FireWorkBaker : Baker<FireworkAuthoring>
{
    public override void Bake(FireworkAuthoring authoring)
    {
        Unity.Mathematics.Random R = new Unity.Mathematics.Random(123456);
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new FireworkSpeed{
            speed = authoring.speed
        });
        AddComponent(entity, new FireworkMaxHeight{
            maxHeight = R.NextFloat(200, 500)
        });
        AddComponent(entity, new FireworkEnd{
            explosionPrefab = GetEntity(authoring.explosionPrefab, TransformUsageFlags.Dynamic),
            Amount = R.NextInt(200, 500)
        });
    }
}
/*
public partial struct FireworkLauncherSystem : ISystem
{
   [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        //state.RequireForUpdate<ShooterCfg>();
    }
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

    void Execute(Entity entity, ref LocalTransform transform, ref FireworkConfig fireworkConfig, ref FireworkSpeed fireworkSpeed)
    {
        fireworkConfig.timer += DeltaTime;
        float R = (float)(fireworkConfig.risingSpeed - ((fireworkConfig.decaySpeed/fireworkConfig.timer)+ (Mathf.Sin(fireworkConfig.explosionTime)/(0.8* fireworkConfig.timer)))*2);
        float D = (float)(fireworkConfig.decaySpeed + ((fireworkConfig.risingSpeed/fireworkConfig.timer)+ (Mathf.Cos(fireworkConfig.explosionTime)/(0.8* fireworkConfig.timer)))*2);
        fireworkSpeed.Speed = -(R-D);
        if(fireworkSpeed.Destroy == true){

            //Actually delete and put explosion here
            ECB.DestroyEntity(entity);
        }
        transform.Position += (transform.Up() * fireworkSpeed.Speed * DeltaTime);
    }
}
*/
