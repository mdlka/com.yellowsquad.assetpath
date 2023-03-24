using System;
using UnityEditor;
using YellowSquad.AssetPath;
using Object = UnityEngine.Object;

[CustomPropertyDrawer(typeof(AssetPathAttribute))]
internal sealed class AssetPathDrawer : BaseAssetPathDrawer
{
    protected override Type ObjectType => (attribute as AssetPathAttribute).Type;
    
    protected override SerializedProperty Property(SerializedProperty rootProperty) => rootProperty;
    protected override void BeforeSelection(Object newSelection, SerializedProperty property) { }
}