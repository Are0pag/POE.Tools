using System;
using System.Linq;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{

    static public class ComponentSearcher
    {
        static public TSearchingComponent TryFindComponentInChildsRecursive<TSearchingComponent>(this Transform parent)
            where TSearchingComponent : Component 
        {
            try {
                return Find<TSearchingComponent>(parent);
            }
            catch (StackOverflowException e) {
                Debug.Log($"{e.Message}\nStack Overflow In Parent: {e.StackTrace}");
                return null;
            }
        }

        static private TSearchingComponent Find<TSearchingComponent>(Transform parent) 
            where TSearchingComponent : Component 
        {
            return parent.TryGetComponent(out TSearchingComponent component) 
                ? component 
                : (from Transform child in parent 
                    select child.TryFindComponentInChildsRecursive<TSearchingComponent>())
                    .FirstOrDefault(comp => comp != null);
        }
    }
}