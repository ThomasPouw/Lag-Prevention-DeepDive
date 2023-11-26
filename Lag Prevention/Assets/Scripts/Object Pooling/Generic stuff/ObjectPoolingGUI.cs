using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPoolingGUI : MonoBehaviour
{
    public TMP_Text FPSCounter;
    [SerializeField] private float _hudRefreshRate = 1f;
 
    private float _timer;
 
    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            FPSCounter.text = "FPS: " + fps;
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }
}
