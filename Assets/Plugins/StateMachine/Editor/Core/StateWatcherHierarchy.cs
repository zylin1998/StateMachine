using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace StateMachineX.Internal
{
    [InitializeOnLoad]
    public static class StateWatcherHierarchy
    {
        public static Color StateColor   { get; set; }
        public static Color MachineColor { get; set; }
        public static Color WrappedColor { get; set; }
        public static float RectAlpha    { get; set; }

        static StateWatcherHierarchy()
        {
            StateColor   = Color.blue;
            MachineColor = Color.green;
            WrappedColor = Color.magenta;
            RectAlpha    = 0.2f;

            EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
        }

        private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            if (!Application.isPlaying) 
            {
                return;
            }

            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (!gameObject)
            {
                return;
            }

            var watcher = gameObject.GetComponent<INodeWatcher>();

            if (watcher != null && watcher.IsCurrent) 
            {
                var color = StateColor;

                if (watcher.Node is IWrappableMachine wrappable)
                {
                    color = WrappedColor;
                }

                else if (watcher.Node is IStateMachine machine)
                {
                    color = MachineColor;
                }

                color.a = RectAlpha;

                selectionRect.xMax += 60f;

                EditorGUI.DrawRect(selectionRect, color);
            }  
        }
    }
}
