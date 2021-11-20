using System;
using UnityEngine;

namespace FinalProject.Architecture.Utils.Attributes.ClassReference
{
    [Serializable]
    public class ClassReferenceAttribute: PropertyAttribute
    {
        public Type Type { get; }

        public ClassReferenceAttribute(Type type)
        {
            Type = type;
        }
    }
}