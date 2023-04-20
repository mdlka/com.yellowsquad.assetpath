<h1 align="center">Asset Path</h1>
<p align="center"><i>Unity package. Provides the "ResourcesReference" class for serializing an asset reference from the Resources folder into an asset path. With "Load" method for easy loading from Resources.</i></p>

<p align="center">
  <img src="https://img.shields.io/github/license/mdlka/com.yellowsquad.assetpath" />
  <img src="https://img.shields.io/github/repo-size/mdlka/com.yellowsquad.assetpath" />
  <img src="https://img.shields.io/github/issues/mdlka/com.yellowsquad.assetpath" />
  <img src="https://img.shields.io/github/v/release/mdlka/com.yellowsquad.assetpath?include_prereleases" />
  <a href="https://openupm.com/packages/com.yellowsquad.assetpath/"><img src="https://img.shields.io/npm/v/com.yellowsquad.assetpath?label=openupm&registry_uri=https://package.openupm.com" /></a>
</p>

---
## Install from Unity Package Manager
Make sure you have standalone Git installed first. Reboot after installation.  
In Unity, open "Window" -> "Package Manager".  
Click the "+" sign on top left corner -> "Add package from git URL..."  
Paste this: https://github.com/mdlka/com.yellowsquad.assetpath.git#2.1.1  
See minimum required Unity version in the package.json file.  
Find "Samples" in the package window and click the "Import" button. Use it as a guide.  
To update the package, simply add it again while using a different version tag.  

## Usage example

 ```csharp
public class Example : MonoBehavior
{
    [SerializeField] private ResourcesReference<GameObject> _templateResource;

    private void Awake()
    {
        GameObject template = _templateResource.Load();
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
