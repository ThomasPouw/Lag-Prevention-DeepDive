using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

    public partial struct TurretRotationSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state){
            //Idk why this is here...
            //state.RequireForUpdate<Execute.TurretRotation>();
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state){
            quaternion spin = quaternion.RotateY(SystemAPI.Time.DeltaTime * math.PI);
            foreach (var transform in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<Turret>())
            {
                transform.ValueRW.Rotation = math.mul(spin, transform.ValueRO.Rotation);
            }
        }

    }
