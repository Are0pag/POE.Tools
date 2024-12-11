using System;
using UnityEngine;

namespace Scripts.Tools
{
    public class CreationArgs<TType>
        where TType : Component
    {
        public readonly Action<TType> Initialize;
        public readonly string ParentName;
        
        protected readonly string _nameOfGameObject;
        
        public string NameOfGameObject {
            get {
                if (string.IsNullOrEmpty(_nameOfGameObject))
                    return typeof(TType).Name;
                
                return _nameOfGameObject;
            }
        }

        public CreationArgs(Action<TType> initialize, string parentName, string nameOfGameObject) {
            Initialize = initialize;
            _nameOfGameObject = nameOfGameObject;
            ParentName = parentName;
        }

        public CreationArgs(Action<TType> initialize, string parentName) {
            Initialize = initialize;
            ParentName = parentName;
        }

        public CreationArgs(string parentName, string nameOfGameObject) {
            _nameOfGameObject = nameOfGameObject;
            ParentName = parentName;
        }

        public CreationArgs(Action<TType> initialize) {
            Initialize = initialize;
        }

        public CreationArgs(string parentName) {
            ParentName = parentName;
        }
    }
}