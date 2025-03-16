using System.Reflection;
using UnityEngine;
using ENIX;

namespace Utility
{
    public static class ScriptableObjectExtension
    { 
        public static T CloneInstance<T>(this T instance) where T : ScriptableObject
        {
            FieldInfo[] fields = typeof(T).GetAllFieldsByType(BindingFlags.Public 
                | BindingFlags.NonPublic | BindingFlags.Instance);

            T newInstance = (T)ScriptableObject.CreateInstance(instance.GetType());

            foreach(FieldInfo field in fields)
            {
                object value = field.GetValue(instance);
                field.SetValue(newInstance, value);
            }

            return newInstance;
        }
    }
}