using System;
using UnityEngine;

namespace MG.TweenSystem
{
    public static class ValueVector2Tween
    {
        public static Tween<Vector2> XValue(this Transform transform, Vector2 from, Vector2 to,
            float duration,
            Action<Vector2> onUpdate) =>
            Tween<Vector2>.SetUp<TweenType>(transform).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector2> XValue(this Transform transform, Vector2 to, float duration,
            Action<Vector2> onUpdate) =>
            Tween<Vector2>.SetUp<TweenType>(transform).SetOnUpdate(onUpdate).Initialize(duration, to);


        public static Tween<Vector2> XValue(this GameObject gameObject, Vector2 from, Vector2 to,
            float duration,
            Action<Vector2> onUpdate) =>
            Tween<Vector2>.SetUp<TweenType>(gameObject).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector2> XValue(this GameObject gameObject, Vector2 to, float duration,
            Action<Vector2> onUpdate) =>
            Tween<Vector2>.SetUp<TweenType>(gameObject).SetOnUpdate(onUpdate).Initialize(duration, to);


        public static Tween<Vector2> XValue(this Component component, Vector2 from, Vector2 to,
            float duration,
            Action<Vector2> onUpdate) =>
            Tween<Vector2>.SetUp<TweenType>(component).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector2> XValue(this Component component, Vector2 to, float duration,
            Action<Vector2> onUpdate) =>
            Tween<Vector2>.SetUp<TweenType>(component).SetOnUpdate(onUpdate).Initialize(duration, to);


        private class TweenType : Tween<Vector2>
        {
            private Action<Vector2> onUpdate;
            public override bool OnInitialize() => true;
            public override Vector2 GetFrom() => Vector2.zero;

            public override void OnUpdate(float easedTime)
            {
                currentValue.x = Interpolate(fromValue.x, toValue.x, easedTime);
                currentValue.y = Interpolate(fromValue.y, toValue.y, easedTime);
                onUpdate?.Invoke(currentValue);
            }

            public Tween<Vector2> SetOnUpdate(Action<Vector2> OnUpdate)
            {
                onUpdate = OnUpdate;
                return this;
            }
        }
    }
}