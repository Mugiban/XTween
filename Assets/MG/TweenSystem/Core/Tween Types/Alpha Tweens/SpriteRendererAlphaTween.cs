using UnityEngine;

namespace MG.TweenSystem
{
    public static class SpriteRendererAlphaTween
    {
        public static Tween<float>
            XAlpha(this SpriteRenderer spriteRenderer, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(spriteRenderer).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAlpha(this SpriteRenderer spriteRenderer, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(spriteRenderer).Initialize(duration, to);
        
        
        public static Tween<float>
            XSpriteAlpha(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XSpriteAlpha(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XSpriteAlpha(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XSpriteAlpha(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XSpriteAlpha(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XSpriteAlpha(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private SpriteRenderer spriteRenderer;
            private Color color;

            public override bool OnInitialize()
            {
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                return spriteRenderer != null;
            }

            public override float GetFrom() => spriteRenderer.color.a;

            public override void OnUpdate(float easedTime)
            {
                color = spriteRenderer.color;
                currentValue = Interpolate(fromValue, toValue, easedTime);
                color.a = currentValue;
                spriteRenderer.color = color;
            }
        }
    }
}