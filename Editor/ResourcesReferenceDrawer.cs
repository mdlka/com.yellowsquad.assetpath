using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace YellowSquad.AssetPath.Editor
{
    [CustomPropertyDrawer(typeof(ResourcesReference<>), true)]
    internal class ResourcesReferenceDrawer : PropertyDrawer
    {
        private SerializedProperty _objectAssetProperty;
        private SerializedProperty _projectPathProperty;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _objectAssetProperty = property.FindPropertyRelative("_objectAsset");
            _projectPathProperty = property.FindPropertyRelative("_projectPath");

            position.height = EditorGUIUtility.singleLineHeight;
            DrawObjectReferenceField(position, property, label);
        }
        
        private void DrawObjectReferenceField(Rect position, SerializedProperty property, GUIContent label)
        {
            Type objectType = property.GetValue().GetType().GenericTypeArguments[0];
            Object propertyValue = _objectAssetProperty.objectReferenceValue;

            EditorGUI.BeginChangeCheck();
            propertyValue = EditorGUI.ObjectField(position, label, propertyValue, objectType, false);

            if (EditorGUI.EndChangeCheck())
                ApplyPropertyChange(propertyValue);
        }
        
        private void ApplyPropertyChange(Object objectAsset)
        {
            string assetProjectPath = string.Empty;

            if (objectAsset != null)
            {
                string projectPath = AssetDatabase.GetAssetPath(objectAsset);

                if (Resources.Load(new ResourcesPath(projectPath).Value()) != null)
                    assetProjectPath = projectPath;
            }

            _projectPathProperty.stringValue = assetProjectPath;
            _objectAssetProperty.objectReferenceValue = objectAsset;
        }
    }
}