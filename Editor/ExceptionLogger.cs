using System;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    static public class ExceptionLogger
    {
        static public void Log(Exception exception, object source = null) {
            Debug.Log($"" +
                      $"{exception.GetType().Name}" +
                      $" from {source?.GetType().Name}" +
                      $" || Namespace: {source?.GetType().Namespace}" +
                      $" || Assembly: {source?.GetType().Assembly.GetName().Name}");
        }
    }
}