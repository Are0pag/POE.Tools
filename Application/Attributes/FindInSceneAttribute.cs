using System;
using UnityEngine;

namespace Scripts.Tools.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class FindInSceneAttribute : PropertyAttribute
    {
        
    }
}