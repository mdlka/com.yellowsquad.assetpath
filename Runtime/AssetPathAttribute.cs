using System;
using UnityEngine;

namespace YellowSquad.AssetPath
{
    /// <summary>
    /// Should only be applied to string types.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class AssetPathAttribute : PropertyAttribute
    {
        public AssetPathAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; }
    }
}
