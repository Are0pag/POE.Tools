using UnityEngine;

namespace Scripts.Tools.View
{
    [System.Serializable]
    public class ViewItemStyle
    {
        [field: SerializeField] public string Label { get; protected set; }
        [field: SerializeField] public Sprite Sprite { get; protected set; }
    }
    
    
}