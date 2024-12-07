using UnityEngine;

namespace Scripts.Tools.Attributes.CustomEdit
{
    static internal class Controller
    {
        static internal void OnAssemblyDataStored() {
            InitializeScene();
        }

        static internal void InitializeScene() {
            new FindAttributeInitializer().InitializeTargetFields();
            new GetComponentAttributeInitializer().InitializeTargetFields();
        }
    }
}