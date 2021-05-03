using UnityEngine;

namespace MG.TweenSystem
{
    public static class SpriteRendererColorTween
    {
        
        public static Tween<Color>
            XColor(this SpriteRenderer spriteRenderer, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(spriteRenderer).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XColor(this SpriteRenderer spriteRenderer, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(spriteRenderer).Initialize(duration, to);
        
        
        public static Tween<Color>
            XSpriteColor(this GameObject gameObject, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XSpriteColor(this GameObject gameObject, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<Color>
            XSpriteColor(this Transform transform, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XSpriteColor(this Transform transform, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<Color>
            XSpriteColor(this Component component, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XSpriteColor(this Component component, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<Color>
        {
            private SpriteRenderer spriteRenderer;

            public override bool OnInitialize()
            {
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                return spriteRenderer != null;
            }

            public override Color GetFrom() => spriteRenderer.color;

            public override void OnUpdate(float easedTime)
            {
                currentValue.r = Interpolate(fromValue.r, toValue.r, easedTime);
                currentValue.g = Interpolate(fromValue.g, toValue.g, easedTime);
                currentValue.b = Interpolate(fromValue.b, toValue.b, easedTime);
                currentValue.a = Interpolate(fromValue.a, toValue.a, easedTime);
                spriteRenderer.color = currentValue;
            }
        }
    }
}