using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoObjectPooling : MonoBehaviour, IObjectPooling
{
    public GameObject Object;
    public GameObject GetPooledObject()
    {
        return Instantiate(Object);
    }
}
