using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(GameObject))]
public class returnToPool : MonoBehaviour
{
    public GameObject Object;
    public IObjectPool<GameObject> pool;
    private void Start() {
        
    }

    void OnDisable() 
    {
        pool.Release(gameObject);
    }
}
public class ObjectPoolingUnity : MonoBehaviour, IObjectPooling{
    public GameObject Object;
    public bool collectionChecks = true;
    public int poolSize = 10;

    IObjectPool<GameObject> m_Pool;
    public IObjectPool<GameObject> Pool
    {
        get {
            if (m_Pool == null)
            {
                m_Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, poolSize, poolSize);
            }
            return m_Pool;
        }
    }
    GameObject CreatePooledItem(){
        GameObject obj = Instantiate(Object);
        obj.SetActive(false);
        var returnToPool = obj.AddComponent<returnToPool>();
        returnToPool.pool = Pool;
        return obj;

    }
    void OnReturnedToPool(GameObject system)
    {
        system.gameObject.SetActive(false);
    }
    void OnTakeFromPool(GameObject system)
    {
        system.gameObject.SetActive(true);
    }
    void OnDestroyPoolObject(GameObject system)
    {
        Destroy(system.gameObject);
    }
    public GameObject GetPooledObject()
    {
        return Pool.Get();
    }
}

