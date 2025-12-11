using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

namespace StateMachineX.Editor
{
    [CustomEditor(typeof(MonoNodeWatcher))]
    public class NodeWatcherEditor : UnityEditor.Editor
    {
        public static bool DefaultFoldState { get; set; } = true;

        private BoolRef frameFold        = new BoolRef(DefaultFoldState);
        private BoolRef timeFold         = new BoolRef(DefaultFoldState);
        private BoolRef parameterFold    = new BoolRef(DefaultFoldState);
        private BoolRef machineFold      = new BoolRef(DefaultFoldState);
        private BoolRef activeStatesFold = new BoolRef(DefaultFoldState);
        private BoolRef allStatesFold    = new BoolRef(DefaultFoldState);
        private BoolRef sequenceFold     = new BoolRef(DefaultFoldState);

        private Dictionary<int, BoolRef> parameterFolds = new Dictionary<int, BoolRef>();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var watcher = PaintBasicInformation();
            var node    = watcher.Node;

            PaintStateMachine(node);

            Repaint();
        }

        private MonoNodeWatcher PaintBasicInformation() 
        {
            var watcher = this.target as MonoNodeWatcher;

            if (watcher)
            {
                watcher.Node.Identity?.AsLabel("Identity");

                PaintFrame(watcher);

                PaintTime(watcher);

                PaintParameters(watcher.Node);
            }

            return watcher;
        }

        private void PaintFrame(INodeWatcher watcher)
        {
            var indentLevel = EditorGUI.indentLevel;
            
            EditorGUI.indentLevel = 0;

            frameFold.Value = EditorGUILayout.BeginFoldoutHeaderGroup(frameFold, "Frame");

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

        private void PaintTime(INodeWatcher watcher)
        {
            var indentLevel = EditorGUI.indentLevel;

            EditorGUI.indentLevel = 0;

            timeFold.Value = EditorGUILayout.BeginFoldoutHeaderGroup(timeFold, "Time");

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

        private void PaintParameters(IMachineNode node)
        {
            var objects = node.GetParameters();

            if (objects.Length <= 0) { return; }

            var indentLevel = EditorGUI.indentLevel;

            EditorGUI.indentLevel = 0;

            parameterFold.Value = EditorGUILayout.BeginFoldoutHeaderGroup(parameterFold, "Parameters");

            EditorGUI.indentLevel = 1;

            if (parameterFold)
            {
                var index = 0;
                foreach (var obj in objects)
                {
                    index++;

                    DisplayObject(1, obj, index);
                }
            }

            EditorGUI.indentLevel = indentLevel;
        }

        private bool PaintStateMachine(IMachineNode node)
        {
            var indentLevel = EditorGUI.indentLevel;

            if (node is IStateMachine machine)
            {
                EditorGUI.indentLevel = 0;

                machineFold.Value = EditorGUILayout.BeginFoldoutHeaderGroup(machineFold, "StateMachine");

                EditorGUI.indentLevel = 1;

                if (machineFold)
                {
                    activeStatesFold.Value = EditorGUILayout.Foldout(activeStatesFold, "Active States");
                    
                    var watcher = machine.Current?.Watcher;

                    if (watcher is MonoNodeWatcher current && activeStatesFold)
                    {
                        current.AsObjectField("CurrentState");
                    }

                    else if (machine.Current is IEnumerable<IState> multiStates && activeStatesFold) 
                    {
                        DisplayStates(1, multiStates);
                    }

                    allStatesFold.Value = EditorGUILayout.Foldout(allStatesFold, "All States");

                    if (allStatesFold)
                    {
                        DisplayStates(1, machine.States);
                    }

                    var sequence = GetSequenceMachine(machine as IWrappableMachine);

                    if (sequence != null)
                    {
                        sequenceFold.Value = EditorGUILayout.Foldout(sequenceFold, "Sequence");

                        if (sequenceFold)
                        {
                            sequence.Active.AsField("Active");
                            sequence.Cycle.AsField("Cycle");
                            sequence.IgnoreEnter.AsField("IgnoreEnter");
                        }
                    }
                }

                EditorGUILayout.EndFoldoutHeaderGroup();

                EditorGUI.indentLevel = indentLevel;

                return true;
            }

            return false;
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

        private void DisplayObject(int indentLevel, object obj, int index) 
        {
            var lastLevel = EditorGUI.indentLevel;

            EditorGUI.indentLevel = indentLevel;

            var hash = obj.GetHashCode();

            var parameter = GetReference(hash);

            parameter.Value = EditorGUILayout.Foldout(parameter, "Parameter " + index);

            if (parameter)
            {
                if (obj is UnityEngine.Object unityObj)
                {
                    unityObj.AsObjectField("UnityObject");
                }

                obj.Draw();
            }

            EditorGUI.indentLevel = lastLevel;
        }

        private BoolRef GetReference(int hash) 
        {
            if (!parameterFolds.TryGetValue(hash, out var reference)) 
            {
                reference = new BoolRef(DefaultFoldState);

                parameterFolds.TryAdd(hash, reference);
            }

            return reference;
        }

        private ISequenceStateMachine GetSequenceMachine(IWrappableMachine machine) 
        {
            if (machine is ISequenceStateMachine self) 
            {
                return self;
            }

            if (machine?.Core is ISequenceStateMachine core)
            {
                return core;
            }

            if (machine?.Core is IWrappableMachine wrappable) 
            {
                return GetSequenceMachine(wrappable);
            }

            return default;
        }
    }
}
