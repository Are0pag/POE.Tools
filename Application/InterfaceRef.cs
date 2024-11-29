using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scripts.Tools
{
    /// <summary>
    /// Allows to serialize component reference that implement this interface. Use Value property to get interface implementation.
    /// </summary>
    [Serializable]
    public class InterfaceRef<TInterface, TObject>
        where TInterface : class // какой интерфейс реализует?
        where TObject : Object // объект какого типа реализует интейрфейс?
    {
        [SerializeField] private TObject _ref;

        /// <summary>
        ///     Provide access to the interface implementation
        /// </summary>
        public TInterface Value {
            get => _ref switch {
                null => null,
                TInterface @interface => @interface, // if it is type of TInterface => return underline value, casts to TInterface
                _ => throw new InvalidOperationException($"{_ref} needs to implement interface {typeof(TInterface)}.")
            };
            set => _ref = value switch {
                null => null,
                TObject newValue => newValue, // if value is TObject => set value casted in TObject
                _ => throw new ArgumentException($"{value} needs to be of type {typeof(TObject)}")
            };
        }
    }


    /// <summary>
    ///  Simplified version of class InterfaceRef where TObject is default Unity Object
    /// </summary>
    [Serializable]
    public class InterfaceRef<TInterface> : InterfaceRef<TInterface, Object> 
        where TInterface : class
    {
    }
}