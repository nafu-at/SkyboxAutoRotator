using UnityEditor;

namespace NafuSoft.SkyboxAutoRotater
{
    [CustomEditor(typeof(SkyboxAutoRotator))]
    public class SkyboxAutoRotatorEditor : Editor
    {
        private SkyboxAutoRotator rotater => target as SkyboxAutoRotator;
        public override void OnInspectorGUI()
        {
            rotater.isAutoRotate = EditorGUILayout.Toggle("Enable Auto Rotation", rotater.isAutoRotate);
            rotater.rotateSpeed = EditorGUILayout.FloatField("Rotate Speed", rotater.rotateSpeed);

            // draw rotation value
            EditorGUI.BeginDisabledGroup(rotater.isAutoRotate);
            var rotateValueInput = EditorGUILayout.FloatField("Rotation", rotater.rotateValue);
            if (rotater.isAutoRotate == false && rotateValueInput != rotater.rotateValue)
                rotater.rotateValue = rotateValueInput;
            EditorGUI.EndDisabledGroup();
        }
    }
}
