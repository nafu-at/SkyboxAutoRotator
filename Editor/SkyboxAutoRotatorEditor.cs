using UnityEditor;
using UnityEngine;

namespace NafuSoft.SkyboxAutoRotater
{
    [CustomEditor(typeof(SkyboxAutoRotator))]
    public class SkyboxAutoRotatorEditor : Editor
    {
        private SkyboxAutoRotator rotater => target as SkyboxAutoRotator;
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("isAutoRotate"), new GUIContent("Enable Auto Rotation"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("rotateSpeed"), new GUIContent("Rotation Speed"));

            // draw rotation value
            EditorGUI.BeginDisabledGroup(rotater.isAutoRotate);
            var rotateValueInput = EditorGUILayout.FloatField("Rotation", rotater.rotateValue);
            if (rotater.isAutoRotate == false && rotateValueInput != rotater.rotateValue)
                rotater.rotateValue = rotateValueInput;
            EditorGUI.EndDisabledGroup();

            EditorGUILayout.HelpBox("このスクリプトがアタッチされている場合、他のスクリプトからSkyboxのRotationを変更することはできません。", MessageType.Warning);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
