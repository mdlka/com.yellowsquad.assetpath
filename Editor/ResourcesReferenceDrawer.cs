using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace YellowSquad.AssetPath.Editor
{
    [CustomPropertyDrawer(typeof(ResourcesReference<>), true)]
    internal class ResourcesReferenceDrawer : PropertyDrawer
    {
        private SerializedProperty _guidProperty;
        private SerializedProperty _projectPathProperty;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _guidProperty = property.FindPropertyRelative("_guid");
            _projectPathProperty = property.FindPropertyRelative("_projectPath");

            position.height = EditorGUIUtility.singleLineHeight;
            DrawObjectReferenceField(position, property, label);
        }
        
        private void DrawObjectReferenceField(Rect position, SerializedProperty property, GUIContent label)
        {
            Type objectType = property.GetValue().GetType().GenericTypeArguments[0];
            
            Object propertyValue = null;
            string assetGuid = _guidProperty.stringValue;

            propertyValue = string.IsNullOrEmpty(assetGuid) ? null : AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(assetGuid), objectType);

            EditorGUI.BeginChangeCheck();
            propertyValue = EditorGUI.ObjectField(position, label, propertyValue, objectType, false);

            if (EditorGUI.EndChangeCheck())
                ApplyAssetGuid(propertyValue);
        }
        
        private void ApplyAssetGuid(Object assetObject)
        {
            string assetGuid = string.Empty;
            string assetProjectPath = string.Empty;

            if (assetObject != null)
            {
                string projectPath = AssetDatabase.GetAssetPath(assetObject);

                if (Resources.Load(new ResourcesPath(projectPath).Value()) != null)
                {
                    assetProjectPath = projectPath;
                    assetGuid = AssetDatabase.AssetPathToGUID(assetProjectPath);
                }
            }

            _guidProperty.stringValue = assetGuid;
            _projectPathProperty.stringValue = assetProjectPath;
        }
    }
}