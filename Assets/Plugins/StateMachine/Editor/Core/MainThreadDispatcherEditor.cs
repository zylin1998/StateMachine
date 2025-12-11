using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using StateMachineX.Internal;
using System.Linq;

namespace StateMachineX.Editor
{
    [CustomEditor(typeof(MainThreadDispatcher))]
    public class MainThreadDispatcherEditor : UnityEditor.Editor
    {
        public static bool DefaultFoldState { get; set; } = false;

        private BoolRef registrationFold    = new BoolRef(DefaultFoldState);
        private BoolRef poolInformationFold = new BoolRef(DefaultFoldState);

        private Dictionary<int, BoolRef> folds = new Dictionary<int, BoolRef>();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            PaintRegistration();

            PaintPoolInformation();

            Repaint();
        }

        private void PaintRegistration() 
        {
            var indentLevel = EditorGUI.indentLevel;

            var dispatcher = target as MainThreadDispatcher;

            indentLevel = 0;

            registrationFold.Value = EditorGUILayout.BeginFoldoutHeaderGroup(registrationFold, "Registrations");

            if (registrationFold)
            {
                foreach (var registration in dispatcher.Registrations)
                {
                    DisplayRegistration(1, registration);
                }
            }

            EditorGUILayout.EndFoldoutHeaderGroup();

            EditorGUI.indentLevel = indentLevel;
        }

        private void PaintPoolInformation() 
        {
            var indentLevel = EditorGUI.indentLevel;

            var dispatcher = target as MainThreadDispatcher;

            indentLevel = 0;

            poolInformationFold.Value = EditorGUILayout.BeginFoldoutHeaderGroup(poolInformationFold, "Pool Information");

            if (poolInformationFold)
            {
                var nodePools = PoolUtils.Pools.Values.OrderBy(p => p.TargetType.Name);
                var watchers = PoolUtils.WatcherPool;

                foreach (var nodePool in nodePools) 
                {
                    DisplayNodePools(1, nodePool);
                }

                DisplayWatchers(1, watchers, "NodeWatcherPool");
            }

            EditorGUILayout.EndFoldoutHeaderGroup();

            EditorGUI.indentLevel = indentLevel;
        }

        private void DisplayRegistration(int indentLevel, IMachineRegistration registration) 
        {
            var lastLevel = EditorGUI.indentLevel;

            EditorGUI.indentLevel = indentLevel;

            var foldOut = GetReference(registration.GetHashCode());

            foldOut.Value = EditorGUILayout.Foldout(foldOut, registration.Machine.Identity.ToString());

            if (foldOut) 
            {
                var machine = registration.Machine;

                if (machine.Watcher is MonoBehaviour watcher) 
                {
                    watcher.AsObjectField("StateMachine");
                }

                if (registration.DisposableCatcher is MonoBehaviour catcher)
                {
                    catcher.AsObjectField("DisposableCatcher");
                }

                registration.IsUpdate     .AsField("Update");
                registration.IsFixedUpdate.AsField("FixedUpdate");
                registration.IsLateUpdate .AsField("LateUpdate");
            }
        }

        private void DisplayWatchers(int indentLevel, WatcherPool watchers, string title)
        {
            var lastLevel = EditorGUI.indentLevel;

            EditorGUI.indentLevel = indentLevel;

            var foldOut = GetReference(watchers.GetHashCode());

            foldOut.Value = EditorGUILayout.Foldout(foldOut, title);

            if (foldOut)
            {
                watchers.CreateCount.AsLabel("CreateCount");
                watchers.InPoolCount.AsLabel("InPoolCount");
            }
        }

        private void DisplayNodePools(int indentLevel, NodePool nodePool)
        {
            var lastLevel = EditorGUI.indentLevel;

            EditorGUI.indentLevel = indentLevel;

            var foldOut = GetReference(nodePool.GetHashCode());

            foldOut.Value = EditorGUILayout.Foldout(foldOut, nodePool.TargetType.Name.Replace("`", " "));

            if (foldOut)
            {
                var generics = nodePool.TargetType.GetGenericArguments();

                if (generics.Any()) 
                {
                    for (int index = 0; index < generics.Length; index++) 
                    {
                        generics[index].Name.AsLabel("Parameter Type " + (index + 1));
                    }
                }
                nodePool.CreateCount.AsLabel("CreateCount");
                nodePool.InPoolCount.AsLabel("InPoolCount");
            }
        }

        private BoolRef GetReference(int hash) 
        {
            if (!folds.TryGetValue(hash, out var reference))
            {
                reference = new BoolRef(DefaultFoldState);

                folds.TryAdd(hash, reference);
            }

            return reference;
        }
    }
}
