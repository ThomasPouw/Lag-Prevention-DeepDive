using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OcclusionUI : MonoBehaviour
{
    public List<Image> images;
    // Start is called before the first frame update

    public void ButtonClicked(bool isPortal, bool active){
        if(isPortal){
            if(active){
                images[0].color = Color.green;
                return;
            }
            images[0].color = Color.red;
            return;
        }
        if(active){
            images[1].color = Color.green;
            return;
        }
        images[1].color = Color.red;
    }
}
