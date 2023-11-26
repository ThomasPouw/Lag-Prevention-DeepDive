using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public IObjectPooling objectPooling;
    public int Amount;
    public Transform upperBoundary;
    public Transform bottomBoundary;
    public float DistanceY;
    // Start is called before the first frame update
    void Start()
    {
        DistanceY = ((upperBoundary.position - bottomBoundary.position).y)/Amount ;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            objectPooling = ObjectPooling.instance;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            objectPooling = GetComponent<ObjectPoolingUnity>();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            objectPooling = GetComponent<NoObjectPooling>();
        }
        if(Time.captureFramerate % 120 == 0 && objectPooling != null)
        {
            for (int i = 0; i < Amount; i++)
            {
                GameObject obj = objectPooling.GetPooledObject();
                if(obj != null){
                    obj.transform.position = new Vector3(bottomBoundary.position.x, bottomBoundary.position.y+ (DistanceY*i), bottomBoundary.position.z);
                    obj.SetActive(true);
                    obj.GetComponent<FlyingObject>().enableSpeed();
                }
            }
            
        }
        
    }
}
