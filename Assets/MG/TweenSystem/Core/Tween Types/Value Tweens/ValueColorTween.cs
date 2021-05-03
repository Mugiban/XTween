using System;
using UnityEngine;

namespace MG.TweenSystem
{
    public static class ValueColorTween
    {
        public static Tween<Color> XValue(this Transform transform, Color from, Color to, float duration,
            Action<Color> onUpdate) =>
            Tween<Color>.SetUp<TweenType>(transform).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<Color> XValue(this Transform transform, Color to, float duration,
            Action<Color> onUpdate) =>
            Tween<Color>.SetUp<TweenType>(transform).SetOnUpdate(onUpdate).Initialize(duration, to);


        public static Tween<Color> XValue(this GameObject gameObject, Color from, Color to, float duration,
            Action<Color> onUpdate) =>
            Tween<Color>.SetUp<TweenType>(gameObject).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<Color> XValue(this GameObject gameObject, Color to, float duration,
            Action<Color> onUpdate) =>
            Tween<Color>.SetUp<TweenType>(gameObject).SetOnUpdate(onUpdate).Initialize(duration, to);


        public static Tween<Color> XValue(this Component component, Color from, Color to, float duration,
            Action<Color> onUpdate) =>
            Tween<Color>.SetUp<TweenType>(component).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<Color> XValue(this Component component, Color to, float duration,
            Action<Color> onUpdate) =>
            Tween<Color>.SetUp<TweenType>(component).SetOnUpdate(onUpdate).Initialize(duration, to);

        private class TweenType : Tween<Color>
        {
            private Action<Color> onUpdate = delegate { };
            public override bool OnInitialize() => true;
            public override Color GetFrom() => Color.black;

            public override void OnUpdate(float easedTime)
            {
                currentValue.r = Interpolate(fromValue.r, toValue.r, easedTime);
                currentValue.g = Interpolate(fromValue.g, toValue.g, easedTime);
                currentValue.b = Interpolate(fromValue.b, toValue.b, easedTime);
                currentValue.a = Interpolate(fromValue.a, toValue.a, easedTime);
                onUpdate?.Invoke(currentValue);
            }

            public Tween<Color> SetOnUpdate(Action<Color> OnUpdate)
            {
                onUpdate = OnUpdate;
                return this;
            }
        }
    }
}