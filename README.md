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
    [SerializeField] private SceneReference _scene;

    private void Awake()
    {
        GameObject template = Resources<GameObject>.Load(new ResourcesPath(_templateResourcePath).Value());
        string sceneName = _scene.Name;
    }
}
 ```

### Similar Projects

This project is inspired by [AssetPathAttribute](https://github.com/ByronMayne/AssetPathAttribute)
