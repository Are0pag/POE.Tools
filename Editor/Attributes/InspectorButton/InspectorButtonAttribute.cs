using System;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    /// <summary>
    /// If name of button is not specified, attribute takes original method name
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class InspectorButtonAttribute : PropertyAttribute
    {
        internal string ButtonLabel { get; }
        internal readonly ExecutingMode Mode;

        public InspectorButtonAttribute(ExecutingMode executingMode, string buttonLabel) {
            Mode = executingMode;
            ButtonLabel = buttonLabel;
        }

        public InspectorButtonAttribute(ExecutingMode executingMode) {
            Mode = executingMode;
        }
    }
}