using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using YellowSquad.AssetPath;
using Object = UnityEngine.Object;

[CustomPropertyDrawer(typeof(AssetPathAttribute))]
internal sealed class AssetPathDrawer : PropertyDrawer
{
    private const string InvalidTypeLabel = "Attribute invalid for type ";
    private readonly IDictionary<string, Object> _references = new Dictionary<string, Object>();

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType != SerializedPropertyType.String)
        {
            Rect labelPosition = position;
            labelPosition.width = EditorGUIUtility.labelWidth;
            
            GUI.Label(labelPosition, label);
            
            Rect contentPosition = position;
            contentPosition.x += labelPosition.width;
            contentPosition.width -= labelPosition.width;
            
            EditorGUI.HelpBox(contentPosition, InvalidTypeLabel + fieldInfo.FieldType.Name, MessageType.Error);
        }
        else
        {
            HandleObjectReference(position, property, label);
        }
    }

    private void HandleObjectReference(Rect position, SerializedProperty property, GUIContent label)
    {
        Type objectType = (attribute as AssetPathAttribute).Type;
        Object propertyValue = null;
        string assetPath = property.stringValue;
        
        if (_references.ContainsKey(property.propertyPath))
            propertyValue = _references[property.propertyPath];
        
        if (propertyValue == null && !string.IsNullOrEmpty(assetPath))
        {
            propertyValue = AssetDatabase.LoadAssetAtPath(assetPath, objectType);

            if (propertyValue != null)
                _references[property.propertyPath] = propertyValue;
        }

        EditorGUI.BeginChangeCheck();
        position.height = EditorGUIUtility.singleLineHeight;
        propertyValue = EditorGUI.ObjectField(position, label, propertyValue, objectType, false);
        
        if (EditorGUI.EndChangeCheck())
            Selection(propertyValue, property);
    }

    private void Selection(Object newSelection, SerializedProperty property)
    {
        string assetPath = string.Empty;

        if (newSelection != null)
            assetPath = AssetDatabase.GetAssetPath(newSelection);

        _references[property.propertyPath] = newSelection;
        property.stringValue = assetPath;
    }
}