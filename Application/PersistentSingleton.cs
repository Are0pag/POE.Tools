using UnityEngine;

namespace Scripts.Tools
{
    public class PersistentSingleton<TInstance> : MonoBehaviour where TInstance : Component
    {
        static protected TInstance _instance;
        public bool AutoUnparentOnAwake = true;

        static public bool HasInstance => _instance != null;

        static public TInstance Instance {
            get {
                if (_instance == null) {
                    _instance = FindAnyObjectByType<TInstance>();
                    if (_instance == null) {
                        var go = new GameObject(typeof(TInstance).Name + " Auto-Generated");
                        _instance = go.AddComponent<TInstance>();
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        ///     Make sure to call base.Awake() in override if you need awake.
        /// </summary>
        protected virtual void Awake() {
            InitializeSingleton();
        }

        static public TInstance TryGetInstance() {
            return HasInstance ? _instance : null;
        }

        protected virtual void InitializeSingleton() {
            if (!Application.isPlaying)
                return;

            if (AutoUnparentOnAwake) transform.SetParent(null);

            if (_instance == null) {
                _instance = this as TInstance;
                DontDestroyOnLoad(gameObject);
            }
            else {
                if (_instance != this) Destroy(gameObject);
            }
        }
    }
}