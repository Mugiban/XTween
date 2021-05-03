using UnityEngine;

namespace MG.TweenSystem
{
    public static class TextMeshAlphaTween
    {
        public static Tween<float>
            XAlpha(this TextMesh textMesh, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(textMesh).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAlpha(this TextMesh textMesh, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(textMesh).Initialize(duration, to);
        
        public static Tween<float>
            XTextAlpha(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XTextAlpha(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XTextAlpha(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XTextAlpha(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XTextAlpha(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XTextAlpha(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private TextMesh textMesh;
            private Color color;

            public override bool OnInitialize()
            {
                textMesh = gameObject.GetComponent<TextMesh>();
                return textMesh != null;
            }

            public override float GetFrom() => textMesh.color.a;

            public override void OnUpdate(float easedTime)
            {
                color = textMesh.color;
                currentValue = Interpolate(fromValue, toValue, easedTime);
                color.a = currentValue;
                textMesh.color = color;
            }
        }
    }
}