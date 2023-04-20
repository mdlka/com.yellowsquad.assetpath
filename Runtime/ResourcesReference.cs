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
            return Resources.Load<T>(ResourcesPath);
        }

        public ResourceRequest LoadAsync()
        {
            return Resources.LoadAsync<T>(ResourcesPath);
        }
    }
    
    [Serializable]
    public class ResourcesReference : ISerializationCallbackReceiver
    {
#if UNITY_EDITOR
        [SerializeField] private Object _objectAsset;
#endif
        [SerializeField] private string _projectPath;

        private protected ResourcesReference() { }

        public bool IsNull => string.IsNullOrEmpty(_projectPath);
        public string ResourcesPath => new ResourcesPath(ProjectPath).Value();
        public string ProjectPath
        {
            get
            {
#if UNITY_EDITOR
                return AssetDatabase.GetAssetPath(_objectAsset);
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
            if (_objectAsset == null)
                return;

            string projectPath = AssetDatabase.GetAssetPath(_objectAsset);
            
            if (projectPath.Equals(_projectPath)) 
                return;
            
            _projectPath = projectPath;
            
            if (Application.isPlaying == false)
                EditorSceneManager.MarkAllScenesDirty();
        }
#endif
    }
}