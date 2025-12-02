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
            UnityEngine.Object instance = EditorUtility.InstanceIDToObject(instanceID);

            if (instance is INodeWatcher watcher && watcher.IsCurrent) 
            {
                Debug.Log(instance.name);
                var color = Color.blue;

                if (watcher.Node is IWrappableMachine wrappable)
                {
                    DebugHelper.Log("Is Wrappable StateMachine");

                    color = Color.magenta;
                }

                EditorGUI.DrawRect(selectionRect, color);
            }  
        }
    }
}
