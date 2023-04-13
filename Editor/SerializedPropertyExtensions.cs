using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;

namespace YellowSquad.AssetPath.Editor
{
    internal static class SerializedPropertyExtensions
    {
        private static readonly Regex ArrayPathRegex = new Regex(@"(?<arrayName>\w+)\[(?<index>\d+)\]", RegexOptions.Compiled);
 
        internal static object GetValue(this SerializedProperty property, Func<IEnumerable<string>, IEnumerable<string>> modifier = null)
        {
            IEnumerable<string> path = property.propertyPath.Replace(".Array.data[", "[").Split('.');
            
            if (modifier != null)
                path = modifier(path);
            
            var target = (object)property.serializedObject.targetObject;
            return GetValueRecursive(target, path);
        }
 
        private static object GetValueRecursive(object target, IEnumerable<string> path)
        {
            if (target == null) 
                throw new ArgumentNullException(nameof(target));

            var pathList = path.ToList();
            string head = pathList.FirstOrDefault();
            
            if (head == null)
                return target;
 
            var arrayMatch = ArrayPathRegex.Match(head);
            
            if (arrayMatch.Success)
            {
                head = arrayMatch.Groups["arrayName"].Value;
                int index = int.Parse(arrayMatch.Groups["index"].Value);
                var field = target.GetType().FieldRecursive(head);
                var array = field.GetValue(target) as IEnumerable;
                target = array.ElementAtOrDefault(index);
            }
            else
            {
                target = target.GetType().FieldRecursive(head).GetValue(target);
            }
            
            return GetValueRecursive(target, pathList.Skip(1));
        }

        private static object ElementAtOrDefault(this IEnumerable sequence, int index)
        {
            if (sequence == null) 
                throw new ArgumentNullException(nameof(sequence));
            
            foreach (var element in sequence)
            {
                if (index == 0) 
                    return element;
                
                index--;
            }
            
            return null;
        }

        private static FieldInfo FieldRecursive(this Type type, string fieldName)
        {
            var field = type.Field(fieldName);

            if (field != null)
                return field;

            if (type.BaseType == typeof(object))
                return null;

            return type.BaseType.FieldRecursive(fieldName);
        }

        private static FieldInfo Field(this Type type, string fieldName) 
            => type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
    }
}