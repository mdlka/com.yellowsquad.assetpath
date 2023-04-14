using System;

namespace YellowSquad.AssetPath
{
    internal class ResourcesPath
    {
        private const string ResourcesFolderName = "/Resources/";
        private readonly string _projectPath;

        internal ResourcesPath(string projectPath)
        {
            _projectPath = projectPath;
        }

        internal string Value()
        {
            if (string.IsNullOrEmpty(_projectPath))
                throw new NullReferenceException(nameof(_projectPath));

            int folderIndex = _projectPath.IndexOf(ResourcesFolderName, StringComparison.Ordinal);

            if (folderIndex == -1)
                throw new InvalidOperationException("Asset is not in the Resources folder");

            folderIndex += ResourcesFolderName.Length;
            
            int length = _projectPath.Length - folderIndex;
            length -= _projectPath.Length - _projectPath.LastIndexOf('.');

            return _projectPath.Substring(folderIndex, length);
        }
    }
}