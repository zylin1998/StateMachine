using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

namespace StateMachineX.Editor
{
    internal static class EditorExtensions
    {
        internal static float AsField(this float self, object message) 
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.FloatField(self);

            EditorGUILayout.EndHorizontal();

            return result;
        }

        internal static int AsField(this int self, object message)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.IntField(self);

            EditorGUILayout.EndHorizontal();

            return result;
        }

        internal static bool AsField(this bool self, object message)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.Toggle(self);

            EditorGUILayout.EndHorizontal();

            return result;
        }

        internal static string AsField(this string self, object message)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.TextField(self);

            EditorGUILayout.EndHorizontal();

            return result;
        }


        internal static void AsLabel(this object obj, object message)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            EditorGUILayout.LabelField(obj.ToString());

            EditorGUILayout.EndHorizontal();
        }

        internal static void AsLabelFormat(string title, string format, params object[] args)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(title);

            EditorGUILayout.LabelField(string.Format(format, args));

            EditorGUILayout.EndHorizontal();
        }

        internal static Object AsObjectField(this Object self, object message) 
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.ObjectField(self, self.GetType(), true);

            EditorGUILayout.EndHorizontal();

            return result;
        }
    }
}
