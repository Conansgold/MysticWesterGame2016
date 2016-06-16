using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GeneralButton))]
public class GeneralButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var myButton = target as GeneralButton;
        var globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();


        

        myButton.ChangeSceneOnClick = GUILayout.Toggle(myButton.ChangeSceneOnClick, "Change Scene on Click");

        if (myButton.ChangeSceneOnClick)
        {
            myButton.EndGameOnClick = false;

            myButton.sceneIndex = EditorGUILayout.Popup("Scene name: ", myButton.sceneIndex, globals.SceneNames, EditorStyles.popup);
            myButton.sceneName = globals.SceneNames[myButton.sceneIndex];
        }


        myButton.EndGameOnClick = GUILayout.Toggle(myButton.EndGameOnClick, "End Game on Click");
        if(myButton.EndGameOnClick)
        {
            myButton.ChangeSceneOnClick = false;
            myButton.LoadAnotherMenu = false;
        }

        myButton.EndGameOnClick = GUILayout.Toggle(myButton.EndGameOnClick, "End Game on Click");
        if (myButton.EndGameOnClick)
        {
            myButton.EndGameOnClick = false;

        }
        //var showChildButtons = EditorGUILayout.Foldout(false, "Sub Buttons");
        //if(showChildButtons)
        //{
        //}
    }
}