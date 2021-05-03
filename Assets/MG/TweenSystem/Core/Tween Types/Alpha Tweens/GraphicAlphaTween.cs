using UnityEngine;
using UnityEngine.UI;

namespace MG.TweenSystem
{
    public static class GraphicAlphaTween
    {
        public static Tween<float>
            XAlpha(this Graphic graphic, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(graphic).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAlpha(this Graphic graphic, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(graphic).Initialize(duration, to);
        
        public static Tween<float>
            XGraphicAlpha(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XGraphicAlpha(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XGraphicAlpha(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XGraphicAlpha(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XGraphicAlpha(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XGraphicAlpha(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private Graphic graphic;
            private Color color;

            public override bool OnInitialize()
            {
                graphic = gameObject.GetComponent<Graphic>();
                return graphic != null;
            }

            public override float GetFrom() => graphic.color.a;

            public override void OnUpdate(float easedTime)
            {
                color = graphic.color;
                currentValue = Interpolate(fromValue, toValue, easedTime);
                color.a = currentValue;
                graphic.color = color;
            }
        }
    }
}