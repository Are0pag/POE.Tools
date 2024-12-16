namespace Scripts.Tools
{
    static public class FloatExtensions
    {
        static public bool IsLower(this float originValue, float comparableValue) {
            return originValue < comparableValue;
        }

        static public bool IsHigher(this float originValue, float comparableValue) {
            return originValue > comparableValue;
        }
    }
}