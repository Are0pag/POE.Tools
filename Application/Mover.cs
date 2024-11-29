using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scripts.Tools
{
    static public class Mover
    {
        static public async UniTask MoveAsync(this GameObject movingObject, Vector2 targetPos, float byTime) {
            var elapsedTime = 0f;
            try {
                while (elapsedTime < byTime) {
                    elapsedTime += Time.deltaTime;
                    var time = elapsedTime / byTime;
                    movingObject.transform.position = Vector2.Lerp(movingObject.transform.position, targetPos, time);
                    await UniTask.Yield();
                }
            }
            catch (OperationCanceledException) {
#if UNITY_EDITOR
                Debug.Log("catch OperationCanceledException");
#endif
            }
            catch (MissingReferenceException) {
#if UNITY_EDITOR
                Debug.Log("catch MissingReferenceException");
#endif
            }
        }
    }
}