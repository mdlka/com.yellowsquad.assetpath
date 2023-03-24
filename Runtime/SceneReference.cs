using System;
using UnityEngine;

namespace YellowSquad.AssetPath
{
    [Serializable]
    public struct SceneReference
    {
        [SerializeField] private string _name;
        [SerializeField] private string _path;
        [SerializeField] private int _buildIndex;

        /// <summary>
        /// The name of the scene asset itself. 
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// The asset path to the scene. 
        /// </summary>
        public string Path => _path;

        /// <summary>
        /// The index of the scene in build settings
        /// </summary>
        public int BuildIndex => _buildIndex;

        /// <summary>
        /// Returns back if the scene is in the build or not. 
        /// </summary>
        public bool IsInBuild => BuildIndex >= 0;
    }
}
