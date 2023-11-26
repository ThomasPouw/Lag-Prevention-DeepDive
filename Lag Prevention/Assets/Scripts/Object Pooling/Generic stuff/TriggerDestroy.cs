using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroy : MonoBehaviour
{
    private void OnTriggerExit(Collider other) {
        Destroy(gameObject);
    }
}
