using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace StateMachineX.Editor
{
    [CustomEditor(typeof(MonoNodeWatcher))]
    public class NodeWatcherEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var watcher = this.target as MonoNodeWatcher;

            base.OnInspectorGUI();

            SetBoolean("IsCurrent" , watcher.IsCurrent);
            SetFloat("StartFrame"  , watcher.StartFrame);
            SetFloat("CurrentFrame", watcher.StartFrame + watcher.PassFrame);
            SetFloat("PassFrame"   , watcher.PassFrame);
            SetFloat("StartTime"   , watcher.StartTime);
            SetFloat("CurrentTime" , watcher.StartTime + watcher.PassFrame);
            SetFloat("PassFrame"   , watcher.PassTime);

            Repaint();
        }

        private void SetFloat(string name, float value) 
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(name);

            EditorGUILayout.FloatField(value);

            EditorGUILayout.EndHorizontal();
        }

        private void SetBoolean(string name, bool value)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel(name);

            EditorGUILayout.Toggle(value);

            EditorGUILayout.EndHorizontal();
        }
    }
}
