using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    static internal class Finder
    {
        static public TComponent FindComponentInScene<TComponent>() 
            where TComponent : Component 
        {
            return GameObject.FindFirstObjectByType<TComponent>();
        }
    }
}