using System;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    static public class ExceptionLogger
    {
        static public void Log(Exception exception) {
            if (exception is OperationCanceledException)
                Debug.Log($"{nameof(OperationCanceledException)} from {exception.TargetSite}");

            if (exception is MissingReferenceException) {
                Debug.Log($"{nameof(MissingReferenceException)} from {exception.StackTrace}");
                return;
            }

            Debug.Log(exception.StackTrace);
        }
    }
}