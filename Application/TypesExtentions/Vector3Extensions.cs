namespace Scripts.Tools
{
    static public class Vector3Extensions
    {
        static public UnityEngine.Vector3 Clamp(this UnityEngine.Vector3 vector, UnityEngine.Vector3 min, UnityEngine.Vector3 max) {
            var res = System.Numerics.Vector3.Clamp(
                new System.Numerics.Vector3(vector.x, vector.y, vector.z),
                new System.Numerics.Vector3(min.x, min.y, min.z),
                new System.Numerics.Vector3(max.x, max.y, min.z)
                );
            
            return new UnityEngine.Vector3(res.X, res.Y, res.Z);
        }
    }
}