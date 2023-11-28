using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Renderdistance : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] int Nearplane;
    [SerializeField] int FarPlane;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnInspectorGUI() {
        
    }

    // Update is called once per frame

}
/*[CustomEditor(typeof(Renderdistance))]
public class RenderdistanceEditor: Editor
{
    SerializedProperty camera;
    SerializedProperty nearPlane;
    SerializedProperty farPlane;
    
    void OnEnable()
    {
        camera = serializedObject.FindProperty("_camera");
        nearPlane = serializedObject.FindProperty("Nearplane");
        farPlane = serializedObject.FindProperty("farPlane");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(nearPlane);
        EditorGUILayout.PropertyField(farPlane);
        serializedObject.ApplyModifiedProperties();
    }
    private void OnInspectorUpdate() {
        if(Time.captureFramerate % 120 < 10){
            camera. nearClipPlane = Nearplane;
            camera.farClipPlane = FarPlane;
        }
    }
}*/
