using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    static public class FieldsExtractor
    {
        static public List<FieldInfo> GetSerializeFieldsFromType<TTargetType>(TTargetType targetType)
            where TTargetType : Type
        {
            return targetType
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => Attribute.IsDefined(f, typeof(SerializeField)))
                .ToList();
        }
    }
}