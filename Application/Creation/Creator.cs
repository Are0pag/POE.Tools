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
                if (Application.isPlaying) go.name = creationArgs.NameOfGameObject + " (auto-generated)";
                else go.name = creationArgs.NameOfGameObject;

                if (creationArgs.Parent) {
                    go.transform.SetParent(creationArgs.Parent);
                    return;
                }
                
                if (!string.IsNullOrEmpty(creationArgs.ParentName))
                    if (GameObject.Find(creationArgs.ParentName) is not {} founded)
                        go.transform.parent = go.transform;
            }
        }
        #endif
    }
}