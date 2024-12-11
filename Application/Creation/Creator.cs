using UnityEngine;

namespace Scripts.Tools
{
    static public class Creator
    {
        static public TType CreateMonoBehavior<TType>(CreationArgs<TType> creationArgs = null)
            where TType : Component 
        {
            var go = new GameObject();
            var instance = go.AddComponent<TType>();
            creationArgs?.Initialize?.Invoke(instance);

#if UNITY_EDITOR
            SetCleanEditorView(creationArgs, go);
#endif
            return instance;
        }

#if UNITY_EDITOR
        static private void SetCleanEditorView<TType>(CreationArgs<TType> creationArgs, GameObject go) 
            where TType : Component 
        {
            if (creationArgs != null) {
                go.name = creationArgs.NameOfGameObject + " (auto-generated)";
                if (!string.IsNullOrEmpty(creationArgs.ParentName))
                    go.transform.parent = GameObject.Find(creationArgs.ParentName).transform;
            }
        }
#endif
    }
}