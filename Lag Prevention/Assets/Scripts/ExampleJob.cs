using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Jobs;
using Unity.Collections;
using System;

[BurstCompile]
public struct ExampleJob : IJob
{
    public NativeArray<int> Numbers;
    public NativeArray<int> Multiply;
    public NativeArray<int> Result;

    public void Execute()
    {
        for (int i = 0; i < Numbers.Length; i++)
        {
            Numbers[i] = Numbers[i] * Multiply[i];
        }
        //Debug.Log($"{string.Join(", ", Numbers)}");
    }
}
