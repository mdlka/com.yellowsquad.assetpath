# com.yellowsquad.assetpath

Unity package. Provides an attribute for serializing an asset reference into a string path to the asset.

## How import
Make sure you have standalone Git installed first. Reboot after installation.  
In Unity, open "Window" -> "Package Manager".  
Click the "+" sign on top left corner -> "Add package from git URL..."  
Paste this: https://github.com/mdlka/com.yellowsquad.assetpath.git#1.0.1  
See minimum required Unity version in the package.json file.  
Find "Samples" in the package window and click the "Import" button. Use it as a guide.  
To update the package, simply add it again while using a different version tag.  

### Usage example

 ```csharp
public class Example : MonoBehavior
{
    [SerializeField, AssetPath(typeof(GameObject))] private string _templateResourcePath;

    private void Awake()
    {
        GameObject template = Resources<GameObject>.Load(new ResourcesPath(_templateResourcePath).Value());
    }
}
 ```

### Limitations

Scenes do not have runtime asset references.
There are 2 solutions to this problem:
1. Use conditional compilation

 ```csharp
public class Example : MonoBehavior
{
#if UNITY_EDITOR
    [AssetPath(typeof(SceneAsset))]
#endif
    [SerializeField] private string _scenePath;

    private void Awake()
    {
        int sceneBuildIndex = SceneUtility.GetBuildIndexByScenePath(_scenePath);
    }
}
 ```

2. Use a package that is designed to use scenes. For example: [Eflatun.SceneReference](https://github.com/starikcetin/Eflatun.SceneReference)


### Similar Projects

This project is inspired by [AssetPathAttribute](https://github.com/ByronMayne/AssetPathAttribute)
