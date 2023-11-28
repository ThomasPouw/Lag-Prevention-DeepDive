using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectPoolingGUI : MonoBehaviour
{
    [SerializeField] public List<GameObject> panels;
     public List<Image> images;
 
    private float _timer;
    private void Start() {
        images = new List<Image>();
        images.Add(panels[0].GetComponent<Image>());
        images.Add(panels[1].GetComponent<Image>());
        images.Add(panels[2].GetComponent<Image>());
    }
    public void ButtonClicked(int i){
        switch(i){
            case 1:
            images[0].color = Color.green;
            images[1].color = Color.gray;
            images[2].color = Color.gray;
            break;
            case 2:
            images[0].color = Color.gray;
            images[1].color = Color.yellow;
            images[2].color = Color.gray;
            break;
            case 3:
            images[0].color = Color.gray;
            images[1].color = Color.gray;
            images[2].color = Color.red;
            break;

        }
       
    }
}
