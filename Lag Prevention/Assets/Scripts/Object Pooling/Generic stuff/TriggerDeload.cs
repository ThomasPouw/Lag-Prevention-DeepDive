using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeload : MonoBehaviour
{
    private void OnTriggerExit(Collider other) {
        gameObject.SetActive(false);
    }
}
