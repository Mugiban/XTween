using System;
using UnityEngine;

namespace MG.TweenSystem
{
    public static class ValueFloatTween
    {
        public static Tween<float> XValue(this Transform transform, float from, float to, float duration,
            Action<float> onUpdate) =>
            Tween<float>.SetUp<TweenType>(transform).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<float> XValue(this Transform transform, float to, float duration, Action<float> onUpdate) =>
            Tween<float>.SetUp<TweenType>(transform).SetOnUpdate(onUpdate).Initialize(duration, to);


        public static Tween<float> XValue(this GameObject gameObject, float from, float to, float duration,
            Action<float> onUpdate) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<float> XValue(this GameObject gameObject, float to, float duration,
            Action<float> onUpdate) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetOnUpdate(onUpdate).Initialize(duration, to);


        public static Tween<float> XValue(this Component component, float from, float to, float duration,
            Action<float> onUpdate) =>
            Tween<float>.SetUp<TweenType>(component).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<float> XValue(this Component component, float to, float duration, Action<float> onUpdate) =>
            Tween<float>.SetUp<TweenType>(component).SetOnUpdate(onUpdate).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private Action<float> onUpdate;
            public override bool OnInitialize() => true;
            public override float GetFrom() => 0;

            public override void OnUpdate(float easedTime)
            {
                currentValue = Interpolate(fromValue, toValue, easedTime);
                onUpdate?.Invoke(currentValue);
            }

            public Tween<float> SetOnUpdate(Action<float> OnUpdate)
            {
                onUpdate = OnUpdate;
                return this;
            }
        }
    }
}