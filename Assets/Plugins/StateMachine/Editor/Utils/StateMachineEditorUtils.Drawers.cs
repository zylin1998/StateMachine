using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StateMachineX.Editor
{
    public static partial class StateMachineEditorUtils
    {
        #region Nest Type

        public delegate void OnDraw<T>(T obj);

        internal struct CallbackDrawer<T> : INodeParameterDrawer
        {
            public CallbackDrawer(OnDraw<T> onDraw) 
            {
                _OnDraw = onDraw;
            }

            public Type DrawType => typeof(T);

            private OnDraw<T> _OnDraw;

            public void Draw(object obj) 
            {
                if (obj is T target) 
                {
                    _OnDraw?.Invoke(target);
                }
            }
        }

        #endregion

        static StateMachineEditorUtils() 
        {
            BasicDrawers    = new Dictionary<Type, INodeParameterDrawer>();
            OverrideDrawers = new Dictionary<Type, INodeParameterDrawer>();

            AddBasic<int>       ((value) => value.AsField("Value"));
            AddBasic<float>     ((value) => value.AsField("Value"));
            AddBasic<double>    ((value) => value.AsField("Value"));
            AddBasic<long>      ((value) => value.AsField("Value"));
            AddBasic<bool>      ((value) => value.AsField("Value"));
            AddBasic<string>    ((value) => value.AsField("Value"));
            AddBasic<Bounds>    ((value) => value.AsField("Bounds"));
            AddBasic<BoundsInt> ((value) => value.AsField("BoundsInt"));
            AddBasic<Rect>      ((value) => value.AsField("Rect"));
            AddBasic<RectInt>   ((value) => value.AsField("RectInt"));
            AddBasic<Color>     ((value) => value.AsField("Color"));
            AddBasic<Vector2>   ((value) => value.AsField("Vector2"));
            AddBasic<Vector2Int>((value) => value.AsField("Vector2Int"));
            AddBasic<Vector3>   ((value) => value.AsField("Vector3"));
            AddBasic<Vector3Int>((value) => value.AsField("Vector3Int"));
            AddBasic<Vector4>   ((value) => value.AsField("Vector4"));
        }

        internal static Dictionary<Type, INodeParameterDrawer> BasicDrawers    { get; }
        internal static Dictionary<Type, INodeParameterDrawer> OverrideDrawers { get; }

        public static bool DrawOverride(this object obj) 
        {
            var type = obj.GetType();

            if (OverrideDrawers.TryGetValue(type, out var drawer)) 
            {
                drawer.Draw(obj);

                return true;
            }

            var assigned = OverrideDrawers.Keys.FirstOrDefault(t => t.IsAssignableFrom(type));

            if (OverrideDrawers.TryGetValue(assigned, out var assignedDrawer))
            {
                assignedDrawer.Draw(obj);

                return true;
            }

            return false;
        }

        public static bool DrawBasic(this object obj)
        {
            var type = obj.GetType();

            if (BasicDrawers.TryGetValue(type, out var drawer))
            {
                drawer.Draw(obj);

                return true;
            }

            var assigned = BasicDrawers.Keys.FirstOrDefault(t => t.IsAssignableFrom(type));

            if (BasicDrawers.TryGetValue(assigned, out var assignedDrawer))
            {
                assignedDrawer.Draw(obj);

                return true;
            }

            return false;
        }

        public static void Draw(this object obj)
        {
            if (obj.DrawOverride())
            {
                return;
            }

            obj.DrawBasic();
        }

        internal static bool AddBasic(INodeParameterDrawer drawer)
        {
            return BasicDrawers.TryAdd(drawer.DrawType, drawer);
        }

        internal static bool AddBasic<T>(OnDraw<T> onDraw)
        {
            var drawer = new CallbackDrawer<T>(onDraw);

            return BasicDrawers.TryAdd(drawer.DrawType, drawer);
        }

        internal static bool RemoveBasic<T>()
        {
            return BasicDrawers.Remove(typeof(T));
        }

        public static bool AddOverride(INodeParameterDrawer drawer)
        {
            return OverrideDrawers.TryAdd(drawer.DrawType, drawer);
        }

        public static bool AddOverride<T>(OnDraw<T> onDraw)
        {
            var drawer = new CallbackDrawer<T>(onDraw);

            return OverrideDrawers.TryAdd(drawer.DrawType, drawer);
        }

        public static bool RemoveOverride<T>()
        {
            return OverrideDrawers.Remove(typeof(T));
        }
    }
}
