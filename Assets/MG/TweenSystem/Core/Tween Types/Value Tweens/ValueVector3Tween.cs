using System;
using UnityEngine;

namespace MG.TweenSystem
{
    public static class ValueVector3Tween
    {
        public static Tween<Vector3> XValue(this Transform transform, Vector3 from, Vector3 to,
            float duration,
            Action<Vector3> onUpdate) =>
            Tween<Vector3>.SetUp<TweenType>(transform).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector3> XValue(this Transform transform, Vector3 to, float duration,
            Action<Vector3> onUpdate) =>
            Tween<Vector3>.SetUp<TweenType>(transform).SetOnUpdate(onUpdate).Initialize(duration, to);


        public static Tween<Vector3> XValue(this GameObject gameObject, Vector3 from, Vector3 to,
            float duration,
            Action<Vector3> onUpdate) =>
            Tween<Vector3>.SetUp<TweenType>(gameObject).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector3> XValue(this GameObject gameObject, Vector3 to, float duration,
            Action<Vector3> onUpdate) =>
            Tween<Vector3>.SetUp<TweenType>(gameObject).SetOnUpdate(onUpdate).Initialize(duration, to);


        public static Tween<Vector3> XValue(this Component component, Vector3 from, Vector3 to,
            float duration,
            Action<Vector3> onUpdate) =>
            Tween<Vector3>.SetUp<TweenType>(component).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector3> XValue(this Component component, Vector3 to, float duration,
            Action<Vector3> onUpdate) =>
            Tween<Vector3>.SetUp<TweenType>(component).SetOnUpdate(onUpdate).Initialize(duration, to);

        private class TweenType : Tween<Vector3>
        {
            private Action<Vector3> onUpdate;
            public override bool OnInitialize() => true;
            public override Vector3 GetFrom() => Vector3.zero;

            public override void OnUpdate(float easedTime)
            {
                currentValue.x = Interpolate(fromValue.x, toValue.x, easedTime);
                currentValue.y = Interpolate(fromValue.y, toValue.y, easedTime);
                currentValue.z = Interpolate(fromValue.z, toValue.z, easedTime);
                onUpdate?.Invoke(currentValue);
            }

            public Tween<Vector3> SetOnUpdate(Action<Vector3> OnUpdate)
            {
                onUpdate = OnUpdate;
                return this;
            }
        }
    }
}