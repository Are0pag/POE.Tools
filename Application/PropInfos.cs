using System.Collections.Generic;
using System.Reflection;

namespace Scripts.Tools
{
    static public class PropInfos
    {
        static public readonly PropertyInfo AlphaCanvasGroup = typeof(UnityEngine.CanvasGroup).GetProperty("alpha");
        static public readonly PropertyInfo PosTransform = typeof(UnityEngine.Transform).GetProperty("position");
        static public readonly PropertyInfo ScaleTransform = typeof(UnityEngine.Transform).GetProperty("scale");
        
        static public readonly PropertyInfo CameraOrthographicSize = typeof(UnityEngine.Camera).GetProperty("orthographicSize");
        
        static public readonly PropertyInfo LocalPosTransform = typeof(UnityEngine.Transform).GetProperty("localPosition");
        static public readonly PropertyInfo LocalScaleTransform = typeof(UnityEngine.Transform).GetProperty("localScale");
        static public readonly PropertyInfo LocalRotationTransform = typeof(UnityEngine.Transform).GetProperty("localRotation");
        
        static public readonly PropertyInfo SizeDeltaRect = typeof(UnityEngine.RectTransform).GetProperty("sizeDelta");
        static public readonly PropertyInfo AnchoredPosRect = typeof(UnityEngine.RectTransform).GetProperty("anchoredPosition");
    }
}