using System;
using System.Collections.Generic;

namespace FinalProject.Architecture.Utils.Scripts.Editor
{
    public static class UIEditorExtensions {
        public static bool IsArrayOrList(this Type type) {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) || type.IsArray;
        }
    }
}