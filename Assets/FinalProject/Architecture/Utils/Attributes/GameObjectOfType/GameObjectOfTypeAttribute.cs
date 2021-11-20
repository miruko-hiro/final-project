using System;
using UnityEngine;

namespace FinalProject.Architecture.Utils.Attributes.GameObjectOfType
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Field)]
    public class GameObjectOfTypeAttribute: PropertyAttribute
    {
        public Type Type { get; }
        
        /// <summary>
        /// This attribute uses with GameObject only. You can place game objects with different types of scripts. Even interfaces.
        /// </summary>
        /// <param name="type">Class or interface type</param>
        public GameObjectOfTypeAttribute(Type type)
        {
            Type = type;
        }
    }
}