using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour, IObjectPooling
{
    public static ObjectPooling instance;
    public List<GameObject> ListPool;
    [SerializeField] private int amountToPool = 5;
    [SerializeField] GameObject preFab;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < amountToPool; i++){
            GameObject obj = Instantiate(preFab);
            obj.SetActive(false);
            ListPool.Add(obj);
        }
    }

    public GameObject GetPooledObject(){
        for(int i = 0; i < ListPool.Count; i++)
        {
            if(!ListPool[i].activeInHierarchy)
            {
                return ListPool[i];
            }
        }
        return null;
    }
}
