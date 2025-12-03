using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StateMachineX.Editor
{
    internal static partial class StateMachineEditorUtils
    {
        #region Nest Type

        internal struct CallbackDrawer<T> : INodeParameterDrawer
        {
            public CallbackDrawer(Action<T> callback) 
            {
                _Callback = callback;
            }

            public Type DrawType => typeof(T);

            private Action<T> _Callback;

            public void Draw(object obj) 
            {
                if (obj is T target) 
                {
                    _Callback?.Invoke(target);
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
            if (OverrideDrawers.TryGetValue(obj.GetType(), out var drawer)) 
            {
                drawer.Draw(obj);

                return true;
            }

            return false;
        }

        public static bool DrawBasic(this object obj)
        {
            if (BasicDrawers.TryGetValue(obj.GetType(), out var drawer))
            {
                drawer.Draw(obj);

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

        internal static bool AddBasic<T>(Action<T> onDraw)
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

        public static bool AddOverride<T>(Action<T> onDraw)
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
