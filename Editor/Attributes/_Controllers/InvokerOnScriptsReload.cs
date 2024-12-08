using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

namespace Scripts.Tools.Attributes.CustomEdit
{

    [InitializeOnLoad]
    static internal class InvokerOnScriptsReload
    {
        static internal List<MonoBehaviour> StoredMonoBehaviours;
        
        static InvokerOnScriptsReload() { 
            CompilationPipeline.compilationFinished += OnScriptsRecompiled; // Register callback for script compilation completion
        }

        static private void OnScriptsRecompiled(object context) {
            StoreAllMonoBehaviorsFromScene();
        }

        static internal void StoreAllMonoBehaviorsFromScene() {
            StoredMonoBehaviours = new List<MonoBehaviour>();
            foreach (var gameObject in GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None)) {
                foreach (var monoBehaviour in gameObject.GetComponents<MonoBehaviour>()) {
                    if (monoBehaviour.GetType() != typeof(Component)) {
                        StoredMonoBehaviours.Add(monoBehaviour);
                    }
                }
            }
            Controller.OnAssemblyDataStored();
        }
    }
}
