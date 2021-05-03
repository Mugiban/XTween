using UnityEngine;
using UnityEngine.UI;

namespace MG.TweenSystem
{
    public static class GraphicColorTween
    {
        public static Tween<Color>
            XColor(this Graphic graphic, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(graphic).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XColor(this Graphic graphic, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(graphic).Initialize(duration, to);
        
        public static Tween<Color>
            XGraphicColor(this GameObject gameObject, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XGraphicColor(this GameObject gameObject, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<Color>
            XGraphicColor(this Transform transform, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XGraphicColor(this Transform transform, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<Color>
            XGraphicColor(this Component component, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XGraphicColor(this Component component, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<Color>
        {
            private Graphic graphic;

            public override bool OnInitialize()
            {
                graphic = gameObject.GetComponent<Graphic>();
                return graphic != null;
            }

            public override Color GetFrom() => graphic.color;

            public override void OnUpdate(float easedTime)
            {
                currentValue.r = Interpolate(fromValue.r, toValue.r, easedTime);
                currentValue.g = Interpolate(fromValue.g, toValue.g, easedTime);
                currentValue.b = Interpolate(fromValue.b, toValue.b, easedTime);
                currentValue.a = Interpolate(fromValue.a, toValue.a, easedTime);
                graphic.color = currentValue;
            }
        }
    }
}