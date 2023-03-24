using System;
using UnityEditor;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace YellowSquad.AssetPath.Editor
{
    [CustomPropertyDrawer(typeof(SceneReference))]
    internal sealed class SceneReferenceDrawer : BaseAssetPathDrawer
    {
        private SerializedProperty _name;
        private SerializedProperty _buildIndex;
        
        protected override Type ObjectType => typeof(SceneAsset);

        protected override void BeforeSelection(Object newSelection, SerializedProperty property)
        {
            if (newSelection == null)
            {
                _name.stringValue = "";
                _buildIndex.intValue = -1;
            }
            else
            {
                string assetPath = AssetDatabase.GetAssetPath(newSelection);
                Scene scene = SceneManager.GetSceneByPath(assetPath);
                _name.stringValue = scene.name;
                _buildIndex.intValue = scene.buildIndex;
            }
        }
        
        protected override SerializedProperty Property(SerializedProperty rootProperty)
        {
            _name = rootProperty.FindPropertyRelative("_name");
            _buildIndex = rootProperty.FindPropertyRelative("_buildIndex");
            
            return rootProperty.FindPropertyRelative("_path");
        }
    }
}
