using UnityEngine;
using UnityEditor;


public class ParticularlyPromptParenter : EditorWindow {

    public GameObject professionalParent;

    [MenuItem("Window/Particularly Prompt Parenter")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<ParticularlyPromptParenter>("Particularly Prompt Parenter");
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Parent:", EditorStyles.boldLabel);
        professionalParent = (GameObject)EditorGUILayout.ObjectField(professionalParent, typeof(GameObject), true);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Pick Parent"))
        {
            PickParent();
        }

        if (GUILayout.Button("Parent the children"))
        {
            Parent();
        }

        
    }

    void Parent()
    {
        if (professionalParent != null)
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.transform.SetParent(professionalParent.transform);
            }
        }
        else
        {
            Debug.Log("Please pick a parent first");
        }
    }

    void PickParent()
    {
        if(Selection.gameObjects.Length > 0)
        {
            professionalParent = Selection.gameObjects[0];
        }
        else
        {
            Debug.Log("Please select an object to be the parent");
        }
    }
}
