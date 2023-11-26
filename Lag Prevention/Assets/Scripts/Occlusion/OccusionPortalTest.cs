using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccusionPortalTest : MonoBehaviour
{
    public OcclusionPortal occlusionPortal;
    public Animator animator;
    public bool door = false;
    public bool portal= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("Door!");
            door = !door;
            Debug.Log(door);
            animator.SetBool("DoorOpened", door);
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            Debug.Log("Portal!");
            portal = !portal;
            if(occlusionPortal != null)
            occlusionPortal.open = portal;
        }
    }
}
