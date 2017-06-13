using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;


[CustomEditor(typeof(AvatarController))]
public class AvatarControllerEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        AvatarController myAvatarController = (AvatarController)target;

        switch (myAvatarController.Exercises)
        {
            case AvatarController.ExercisesEnum.FullBody:
                myAvatarController.Mirrored = EditorGUILayout.Toggle("Mirrored", myAvatarController.Mirrored);
                myAvatarController.LegLeft = EditorGUILayout.Toggle("LegLeft", myAvatarController.LegLeft);
                myAvatarController.LegRight = EditorGUILayout.Toggle("LegRight", myAvatarController.LegRight);
                myAvatarController.ArmLeft = EditorGUILayout.Toggle("ArmLeft", myAvatarController.ArmLeft);
                myAvatarController.ArmRight = EditorGUILayout.Toggle("ArmRight", myAvatarController.ArmRight);
                break;

            case AvatarController.ExercisesEnum.LegLeft:
                myAvatarController.LegLeft = EditorGUILayout.Toggle("LegLeft", myAvatarController.LegLeft);
                myAvatarController.LegRight = EditorGUILayout.Toggle("LegRight", myAvatarController.LegRight);
                break;

            case AvatarController.ExercisesEnum.LegRight:
                myAvatarController.LegLeft = EditorGUILayout.Toggle("LegLeft", myAvatarController.LegLeft);
                myAvatarController.LegRight = EditorGUILayout.Toggle("LegRight", myAvatarController.LegRight);
                break;

            case AvatarController.ExercisesEnum.ArmLeft:
                myAvatarController.ArmLeft = EditorGUILayout.Toggle("ArmLeft", myAvatarController.ArmLeft);
                myAvatarController.ArmRight = EditorGUILayout.Toggle("ArmRight", myAvatarController.ArmRight);
                break;

            case AvatarController.ExercisesEnum.ArmRight:
                myAvatarController.ArmLeft = EditorGUILayout.Toggle("ArmLeft", myAvatarController.ArmLeft);
                myAvatarController.ArmRight = EditorGUILayout.Toggle("ArmRight", myAvatarController.ArmRight);
                break;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
#endif