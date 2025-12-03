using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace StateMachineX.Editor
{
    [CustomEditor(typeof(MonoNodeWatcher))]
    public class NodeWatcherEditor : UnityEditor.Editor
    {
        private bool frameFold;
        private bool timeFold;
        private bool machineFold;
        private bool activeStatesFold;
        private bool allStatesFold;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var watcher = PaintBasicInformation();
            var node    = watcher.Node;

            if (PaintStateMachine(node)) 
            {

            }
            
            else if (PaintState(node)) 
            {

            }

            Repaint();
        }

        private bool PaintState(IMachineNode node) 
        {
            if (node is IState state) 
            {

                return true;
            }

            return false;
        }

        private bool PaintStateMachine(IMachineNode node)
        {
            var indentLevel = EditorGUI.indentLevel;

            if (node is IStateMachine machine)
            {
                EditorGUI.indentLevel = 0;

                machineFold = EditorGUILayout.BeginFoldoutHeaderGroup(machineFold, "StateMachine");

                EditorGUI.indentLevel = 1;

                if (machineFold)
                {
                    activeStatesFold = EditorGUILayout.Foldout(activeStatesFold, "Active States");
                    
                    var watcher = machine.Current?.Watcher;

                    if (watcher is MonoNodeWatcher current && activeStatesFold)
                    {
                        current.AsObjectField("CurrentState");
                    }

                    else if (machine.Current is IEnumerable<IState> multiStates && activeStatesFold) 
                    {
                        DisplayStates(1, multiStates);
                    }

                    allStatesFold = EditorGUILayout.Foldout(allStatesFold, "All States");

                    if (allStatesFold)
                    {
                        DisplayStates(1, machine.States);
                    }
                }

                EditorGUILayout.EndFoldoutHeaderGroup();

                EditorGUI.indentLevel = indentLevel;

                return true;
            }

            return false;
        }

        private MonoNodeWatcher PaintBasicInformation() 
        {
            var watcher = this.target as MonoNodeWatcher;

            if (watcher)
            {
                watcher.Node.Identity?.AsLabel("Identity");
                
                SetFrame(watcher);

                SetTime(watcher);
            }

            return watcher;
        }

        private void SetFrame(INodeWatcher watcher)
        {
            var indentLevel = EditorGUI.indentLevel;
            
            EditorGUI.indentLevel = 0;

            frameFold = EditorGUILayout.BeginFoldoutHeaderGroup(frameFold, "Frame");

            EditorGUI.indentLevel = 1;

            var startFrame = watcher.StartFrame;
            var passFrame  = watcher.PassFrame;

            if (frameFold)
            {
                startFrame.AsLabel("StartFrame");
                passFrame .AsLabel("PassFrame");
            }

            EditorGUILayout.EndFoldoutHeaderGroup();

            EditorGUI.indentLevel = indentLevel;
        }

        private void SetTime(INodeWatcher watcher)
        {
            var indentLevel = EditorGUI.indentLevel;

            EditorGUI.indentLevel = 0;

            timeFold = EditorGUILayout.BeginFoldoutHeaderGroup(timeFold, "Time");

            EditorGUI.indentLevel = 1;

            var startTime = watcher.StartTime;
            var passTime  = watcher.PassTime;

            if (timeFold)
            {
                startTime.AsLabel("StartTime");
                passTime .AsLabel("PassTime");
            }
            
            EditorGUILayout.EndFoldoutHeaderGroup();
            
            EditorGUI.indentLevel = indentLevel;
        }

        private void DisplayStates(int indentLevel, IEnumerable<IState> states) 
        {
            var lastLevel = EditorGUI.indentLevel;

            EditorGUI.indentLevel = indentLevel;

            foreach (var state in states)
            {
                if (state.Watcher is MonoNodeWatcher mono)
                {
                    mono.AsObjectField(mono.Node.Identity);
                }
            }

            EditorGUI.indentLevel = lastLevel;
        }
    }
}
