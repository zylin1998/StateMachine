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
        static StateWatcherHierarchy()
        {
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
                var color = Color.blue;

                if (watcher.Node is IWrappableMachine wrappable)
                {
                    color = Color.magenta;
                }

                else if (watcher.Node is IStateMachine machine)
                {
                    color = Color.green;
                }

                color.a = 0.2f;

                selectionRect.xMax += 60f;

                EditorGUI.DrawRect(selectionRect, color);
            }  
        }
    }
}
