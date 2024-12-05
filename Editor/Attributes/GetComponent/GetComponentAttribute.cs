using System;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class GetComponentAttribute : PropertyAttribute
    {
        
    }
}