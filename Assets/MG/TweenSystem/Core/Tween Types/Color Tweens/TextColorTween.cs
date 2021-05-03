using UnityEngine;
using UnityEngine.UI;

namespace MG.TweenSystem
{
    public static class TextColorTween
    {
        public static Tween<Color>
            XColor(this TextMesh textMesh, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(textMesh).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XColor(this TextMesh textMesh, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(textMesh).Initialize(duration, to);
        
        
        public static Tween<Color>
            XTextColor(this GameObject gameObject, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XTextColor(this GameObject gameObject, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<Color>
            XTextColor(this Transform transform, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XTextColor(this Transform transform, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<Color>
            XTextColor(this Component component, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XTextColor(this Component component, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<Color>
        {
            private TextMesh text;

            public override bool OnInitialize()
            {
                text = gameObject.GetComponent<TextMesh>();
                return text != null;
            }

            public override Color GetFrom() => text.color;

            public override void OnUpdate(float easedTime)
            {
                currentValue.r = Interpolate(fromValue.r, toValue.r, easedTime);
                currentValue.g = Interpolate(fromValue.g, toValue.g, easedTime);
                currentValue.b = Interpolate(fromValue.b, toValue.b, easedTime);
                currentValue.a = Interpolate(fromValue.a, toValue.a, easedTime);
                text.color = currentValue;
            }
        }
    }
}