using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccusionPortalTest : MonoBehaviour
{
    public OcclusionUI occlusionUI;
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
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            Debug.Log("Door!");
            door = !door;
            Debug.Log(door);
            animator.SetBool("DoorOpened", door);
            occlusionUI.ButtonClicked(false, door);
            
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            Debug.Log("Portal!");
            portal = !portal;
            if(occlusionPortal != null)
            occlusionPortal.open = portal;
            occlusionUI.ButtonClicked(true, portal);
        }
    }
}
