using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleDialogSystem
{
    [CustomPropertyDrawer(typeof(DialogEvents)), CanEditMultipleObjects]
    public class DialogEventsEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var typeRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            var secondRect = new Rect(position.x, position.y + 20f, position.width, EditorGUIUtility.singleLineHeight);
            var thirdRect = new Rect(position.x, position.y + 40f, position.width, EditorGUIUtility.singleLineHeight);

            SerializedProperty type = property.FindPropertyRelative("Type");

            type.intValue = EditorGUI.Popup(typeRect, "Event", type.intValue, type.enumNames);

            var showDialog = property.FindPropertyRelative("ShowDialogEvent");
            var triggerEvent = property.FindPropertyRelative("TriggerActionEvent");
            var listenEvent = property.FindPropertyRelative("ListenToActionEvent");

            switch ((DialogEvents.EventType)type.intValue)
            {
                case DialogEvents.EventType.ShowDialog:
                    var name = showDialog.FindPropertyRelative("CharacterName");
                    name.stringValue = EditorGUI.TextField(secondRect, "Caracter Name", name.stringValue);
                    var dialog = showDialog.FindPropertyRelative("Dialog");
                    dialog.stringValue = EditorGUI.TextField(thirdRect, "Dialog", dialog.stringValue);
                   
                    break;
                case DialogEvents.EventType.HideDialog:                    
                    break;
                case DialogEvents.EventType.TriggerAction:
                    EditorGUI.PropertyField(secondRect, triggerEvent.FindPropertyRelative("Action"));
                    break;
                case DialogEvents.EventType.ListenToAction:
                    EditorGUI.PropertyField(secondRect, listenEvent.FindPropertyRelative("Action"));
                    break;                    
            }

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var type = property.FindPropertyRelative("Type");

            switch ((DialogEvents.EventType)type.intValue)
            {
                case DialogEvents.EventType.ShowDialog:
                    return (50 - EditorGUIUtility.singleLineHeight) + (EditorGUIUtility.singleLineHeight * 2);
                case DialogEvents.EventType.TriggerAction:
                case DialogEvents.EventType.ListenToAction:
                    return (30 - EditorGUIUtility.singleLineHeight) + (EditorGUIUtility.singleLineHeight * 2);
                default:
                    return (10 - EditorGUIUtility.singleLineHeight) + (EditorGUIUtility.singleLineHeight * 2);
            }
        }
    }
}
