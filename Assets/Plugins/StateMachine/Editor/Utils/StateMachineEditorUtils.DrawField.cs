using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

namespace StateMachineX.Editor
{
    public static partial class StateMachineEditorUtils
    {
        internal static int AsField(this int self, object message)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.IntField(self);

            EditorGUILayout.EndHorizontal();

            return result;
        }

        internal static float AsField(this float self, object message) 
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.FloatField(self);

            EditorGUILayout.EndHorizontal();

            return result;
        }

        internal static double AsField(this double self, object message)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.DoubleField(self);

            EditorGUILayout.EndHorizontal();

            return result;
        }

        internal static long AsField(this long self, object message)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.LongField(self);

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

        internal static Bounds AsField(this Bounds self, object message)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.BoundsField(self);

            EditorGUILayout.EndHorizontal();

            return result;
        }

        internal static BoundsInt AsField(this BoundsInt self, object message)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.BoundsIntField(self);

            EditorGUILayout.EndHorizontal();

            return result;
        }

        internal static Rect AsField(this Rect self, object message)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.RectField(self);

            EditorGUILayout.EndHorizontal();

            return result;
        }

        internal static RectInt AsField(this RectInt self, object message)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.RectIntField(self);

            EditorGUILayout.EndHorizontal();

            return result;
        }

        internal static Color AsField(this Color self, object message)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(message?.ToString());

            var result = EditorGUILayout.ColorField(self);
            
            EditorGUILayout.EndHorizontal();

            return result;
        }

        internal static Vector2 AsField(this Vector2 self, object message)
        {
            var result = EditorGUILayout.Vector2Field(message.ToString(), self);

            return result;
        }

        internal static Vector2Int AsField(this Vector2Int self, object message)
        {
            var result = EditorGUILayout.Vector2IntField(message.ToString(), self);

            return result;
        }

        internal static Vector3 AsField(this Vector3 self, object message)
        {
            var result = EditorGUILayout.Vector3Field(message.ToString(), self);

            return result;
        }

        internal static Vector3Int AsField(this Vector3Int self, object message)
        {
            var result = EditorGUILayout.Vector3IntField(message.ToString(), self);
            
            return result;
        }

        internal static Vector4 AsField(this Vector4 self, object message)
        {
            var result = EditorGUILayout.Vector4Field(message.ToString(), self);
            
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
