using UnityEngine;

namespace MG.TweenSystem
{
    public static class LightColorTween
    {
        public static Tween<Color>
            XLightColorTween(this GameObject gameObject, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XLightColorTween(this GameObject gameObject, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<Color>
            XLightColorTween(this Transform transform, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XLightColorTween(this Transform transform, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<Color>
            XLightColorTween(this Component component, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XLightColorTween(this Component component, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<Color>
        {
            private new Light light;
            private Color color;

            public override bool OnInitialize()
            {
                light = gameObject.GetComponent<Light>();
                return light != null;
            }

            public override Color GetFrom() => light.color;

            public override void OnUpdate(float easedTime)
            {
                color = light.color;
                currentValue.r = Interpolate(fromValue.r, toValue.r, easedTime);
                currentValue.g = Interpolate(fromValue.g, toValue.g, easedTime);
                currentValue.b = Interpolate(fromValue.b, toValue.b, easedTime);
                currentValue.a = Interpolate(fromValue.a, toValue.a, easedTime);
                color = currentValue;
                light.color = color;
            }
        }
    }
}