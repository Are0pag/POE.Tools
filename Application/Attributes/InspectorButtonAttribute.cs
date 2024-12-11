using System;
using UnityEngine;

namespace Scripts.Tools.Attributes
{
    /// <summary>
    /// If name of button is not specified, attribute takes original method name, if executing mode is not specified, attribute set ExecutingMode.Both
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class InspectorButtonAttribute : PropertyAttribute
    {
        public string ButtonLabel { get; }
        public readonly ExecutingMode Mode;

        public InspectorButtonAttribute(ExecutingMode executingMode, string buttonLabel) {
            Mode = executingMode;
            ButtonLabel = buttonLabel;
        }

        public InspectorButtonAttribute(ExecutingMode executingMode) {
            Mode = executingMode;
        }

        public InspectorButtonAttribute(string buttonLabel) {
            ButtonLabel = buttonLabel;
            Mode = ExecutingMode.Both;
        }

        public InspectorButtonAttribute() {
            Mode = ExecutingMode.Both;
        }
    }
}