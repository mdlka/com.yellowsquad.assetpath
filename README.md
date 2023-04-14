# com.yellowsquad.assetpath

Unity package. Provides a class for serializing an asset reference into an asset path.

## How import
Make sure you have standalone Git installed first. Reboot after installation.  
In Unity, open "Window" -> "Package Manager".  
Click the "+" sign on top left corner -> "Add package from git URL..."  
Paste this: https://github.com/mdlka/com.yellowsquad.assetpath.git#2.1.0  
See minimum required Unity version in the package.json file.  
Find "Samples" in the package window and click the "Import" button. Use it as a guide.  
To update the package, simply add it again while using a different version tag.  

## Usage example

 ```csharp
public class Example : MonoBehavior
{
    [SerializeField] private ResourcesReference<GameObject> _templateResourcePath;

    private void Awake()
    {
        GameObject template = _templateResourcePath.Load();
    }
}
 ```

 ## Features
 
- In the inspector, the field is drawn as an object reference.
- Method for easy loading from resources.
- Paths are updated during build (guaranteed by the ISerializationCallbackReceiver).

## Limitations

Scenes do not have runtime asset references. Therefore they are not supported by this package.  
If you need a reference to a scene asset, use the package provided for that. For example: [Eflatun.SceneReference](https://github.com/starikcetin/Eflatun.SceneReference)

## Similar Projects

This project is inspired by [AssetPathAttribute](https://github.com/ByronMayne/AssetPathAttribute)
