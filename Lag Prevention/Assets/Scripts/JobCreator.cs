using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

public class JobCreator : MonoBehaviour
{
    public int[] numbers;
    
    public int[] multiply;
    
    public int[] result;
    public NativeArray<int> Nnumbers;
    
    public NativeArray<int> Nmultiply;
    
    public NativeArray<int> Nresult;

    // Start is called before the first frame update
    void Start()
    {
        Nnumbers = new NativeArray<int>(numbers, Allocator.TempJob);
        Nmultiply = new NativeArray<int>(multiply, Allocator.TempJob);
        Nresult = new NativeArray<int>(result, Allocator.TempJob);
        var Job = new ExampleJob {
            Numbers = Nnumbers,
            Multiply = Nmultiply,
            Result = Nresult
        };
        var Job2 = new ExampleJob {
            Numbers = Nnumbers,
            Multiply = Nmultiply,
            Result = Nresult
        };
        var Job3 = new ExampleJob {
            Numbers = Nnumbers,
            Multiply = Nmultiply,
            Result = Nresult
        };
        var Job4 = new ExampleJob {
            Numbers = Nnumbers,
            Multiply = Nmultiply,
            Result = Nresult
        };
        JobHandle jobHandle = Job.Schedule();
        JobHandle jobHandle2 = Job2.Schedule(jobHandle);
        JobHandle jobHandle3 = Job3.Schedule(jobHandle2);
        JobHandle combined = JobHandle.CombineDependencies(jobHandle, jobHandle2, jobHandle3);
        JobHandle jobHandle4 = Job4.Schedule(combined);
        jobHandle4.Complete();
        result = Nresult.ToArray();
        Debug.Log(Nresult.ToArray());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
