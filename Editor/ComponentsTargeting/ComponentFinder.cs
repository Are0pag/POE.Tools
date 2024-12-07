using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    static public class ComponentFinder
    {
        static public TComponent FindComponentInScene<TComponent>() 
            where TComponent : Component 
        {
            return GameObject.FindFirstObjectByType<TComponent>();
        }
    }
}