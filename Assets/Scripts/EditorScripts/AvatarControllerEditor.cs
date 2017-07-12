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

        switch (myAvatarController.Modality)
        {
            case AvatarController.ModalityEnum.FullBody:
                myAvatarController.Mirrored = EditorGUILayout.Toggle("Mirrored", myAvatarController.Mirrored);
                myAvatarController.LegLeft = EditorGUILayout.Toggle("LegLeft", myAvatarController.LegLeft);
                myAvatarController.LegRight = EditorGUILayout.Toggle("LegRight", myAvatarController.LegRight);
                myAvatarController.ArmLeft = EditorGUILayout.Toggle("ArmLeft", myAvatarController.ArmLeft);
                myAvatarController.ArmRight = EditorGUILayout.Toggle("ArmRight", myAvatarController.ArmRight);
                break;

            case AvatarController.ModalityEnum.LegLeft:
                myAvatarController.LegLeft = EditorGUILayout.Toggle("LegLeft", myAvatarController.LegLeft);
                myAvatarController.LegRight = EditorGUILayout.Toggle("LegRight", myAvatarController.LegRight);
                break;

            case AvatarController.ModalityEnum.LegRight:
                myAvatarController.LegLeft = EditorGUILayout.Toggle("LegLeft", myAvatarController.LegLeft);
                myAvatarController.LegRight = EditorGUILayout.Toggle("LegRight", myAvatarController.LegRight);
                break;

            case AvatarController.ModalityEnum.ArmLeft:
                myAvatarController.ArmLeft = EditorGUILayout.Toggle("ArmLeft", myAvatarController.ArmLeft);
                myAvatarController.ArmRight = EditorGUILayout.Toggle("ArmRight", myAvatarController.ArmRight);
                break;

            case AvatarController.ModalityEnum.ArmRight:
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