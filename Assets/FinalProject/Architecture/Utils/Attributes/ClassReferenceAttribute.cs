using System;
using UnityEngine;

namespace FinalProject.Architecture.Utils.Attributes
{
    [Serializable]
    public class ClassReferenceAttribute: PropertyAttribute
    {
        [SerializeField] private Type _type;

        public ClassReferenceAttribute(Type type)
        {
            _type = type;
        }
    }
}