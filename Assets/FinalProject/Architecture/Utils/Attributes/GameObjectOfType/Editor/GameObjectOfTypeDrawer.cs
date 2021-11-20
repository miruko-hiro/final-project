using System;
using FinalProject.Architecture.Utils.Scripts.Editor;
using UnityEditor;
using UnityEngine;

namespace FinalProject.Architecture.Utils.Attributes.GameObjectOfType.Editor
{
    [CustomPropertyDrawer(typeof(GameObjectOfTypeAttribute))]
    public class GameObjectOfTypeDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (property.propertyType != SerializedPropertyType.ObjectReference)
                throw new Exception(
                    $"You can use only GameObject fields with GameObjectOfType attribute. Class: {property.serializedObject.targetObject.GetType()}");
			
            position.height = EditorGUIUtility.singleLineHeight;

            var myAttribute = attribute as GameObjectOfTypeAttribute;
            var isArray = fieldInfo.FieldType.IsArrayOrList();
            var labelName = label.text + $" ({myAttribute.Type.Name})";
            var currentEvent = Event.current;
            var onHovered = position.Contains(currentEvent.mousePosition);

            if (isArray) {
                var partsOfName = label.text.Split(' ');
                labelName = $"{myAttribute.Type.Name} {Convert.ToInt16(partsOfName[1])}";
            }

            if (DragAndDrop.objectReferences.Length > 0 && onHovered) {
                foreach (var o in DragAndDrop.objectReferences) {
                    if (o is GameObject gameObject && gameObject.GetComponent(myAttribute.Type))
                        continue;
                    DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
                }
            }
			
            if (property.objectReferenceValue != null) {
                if (!(property.objectReferenceValue is GameObject go) || go.GetComponent(myAttribute.Type) == null)
                    throw new Exception($"You must add only {myAttribute.Type} objects.");
            }

            property.objectReferenceValue =
                EditorGUI.ObjectField(position, labelName, property.objectReferenceValue, typeof(GameObject), true);
        }
    }
}