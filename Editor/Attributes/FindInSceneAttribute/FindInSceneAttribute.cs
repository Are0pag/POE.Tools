using System;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class FindInSceneAttribute :  PropertyAttribute
    {
        
    }
}