using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    [SerializeField] public Rigidbody rigidbody;
    [SerializeField] public float speed;
    public void enableSpeed(){
        rigidbody.AddExplosionForce(speed, transform.position, 40, 0.0f, ForceMode.Acceleration);
    }
}
