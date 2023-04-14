using System;
using UnityEngine;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace YellowSquad.AssetPath
{
    [Serializable]
    public sealed class ResourcesReference<T> : ResourcesReference where T : Object
    {
        private ResourcesReference() { }
        
        public T Load()
        {
            return Resources.Load<T>(new ResourcesPath(ProjectPath).Value());
        }
    }
    
    public class ResourcesReference : ISerializationCallbackReceiver
    {
        [SerializeField] private string _guid;
        [SerializeField] private string _projectPath;

        private protected ResourcesReference() { }

        public bool IsNull => string.IsNullOrEmpty(_guid);
        public string ProjectPath
        {
            get
            {
#if UNITY_EDITOR
                return AssetDatabase.GUIDToAssetPath(_guid);
#else
                return _projectPath;
#endif
            }
        }

        [Obsolete("Needed for the editor, don't use it in runtime code!", true)]
        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            UpdateProjectPath();
#endif
        }

        [Obsolete("Needed for the editor, don't use it in runtime code!", true)]
        public void OnAfterDeserialize()
        {
#if UNITY_EDITOR
            // OnAfterDeserialize is called in the deserialization thread so we can't touch Unity API.
            // Wait for the next update frame to do it.
            EditorApplication.update += OnAfterDeserializeHandler;
#endif
        }
        
#if UNITY_EDITOR
        private void OnAfterDeserializeHandler()
        {
            EditorApplication.update -= OnAfterDeserializeHandler;
            UpdateProjectPath();
        }

        private void UpdateProjectPath()
        {
            if (string.IsNullOrEmpty(_guid))
                return;

            string projectPath = AssetDatabase.GUIDToAssetPath(_guid);

            if (projectPath.Equals(_projectPath)) 
                return;
            
            _projectPath = projectPath;
            
            if (Application.isPlaying == false)
                EditorSceneManager.MarkAllScenesDirty();
        }
#endif
    }
}