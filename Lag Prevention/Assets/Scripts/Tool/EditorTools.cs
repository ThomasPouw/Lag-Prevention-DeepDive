

using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

[EditorTool("Scene and Game View Checker")]
public class EditorTools : MonoBehaviour 
{
    
    public EditorWindow sceneView;
    public EditorWindow gameView;
    public EditorWindow OcclusionCullingView;
    private float time = 0;
    private void OnEnable() {
        var type = typeof(EditorWindow).Assembly.GetType("UnityEditor.OcclusionCullingWindow");
        OcclusionCullingView = EditorWindow.GetWindow(type, false);
        type = typeof(EditorWindow).Assembly.GetType("UnityEditor.SceneView");
        sceneView = EditorWindow.GetWindow(type, false);
        type = typeof(EditorWindow).Assembly.GetType("UnityEditor.GameView");
        gameView = EditorWindow.GetWindow(type, false);
        Debug.Log(gameView.hasFocus);
        Debug.Log(sceneView.hasFocus);
        Debug.Log(OcclusionCullingView.hasFocus);
        if(!gameView.hasFocus || !sceneView.hasFocus || !OcclusionCullingView.hasFocus){
            Debug.LogError($"Please have these windows  open in the editor: Game, Scene and Occlusion");
        }
    }


}
