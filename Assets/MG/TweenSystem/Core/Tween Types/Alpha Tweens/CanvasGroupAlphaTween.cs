using UnityEngine;

namespace MG.TweenSystem
{
    public static class CanvasGroupAlphaTween
    {
        public static Tween<float>
            XAlpha(this CanvasGroup canvasGroup, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(canvasGroup).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAlpha(this CanvasGroup canvasGroup, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(canvasGroup).Initialize(duration, to);
        
        public static Tween<float>
            XCanvasGroupAlpha(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XCanvasGroupAlpha(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XCanvasGroupAlpha(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XCanvasGroupAlpha(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XCanvasGroupAlpha(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XCanvasGroupAlpha(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private CanvasGroup canvasGroup;

            public override bool OnInitialize()
            {
                canvasGroup = gameObject.GetComponent<CanvasGroup>();
                return canvasGroup != null;
            }

            public override float GetFrom() => canvasGroup.alpha;

            public override void OnUpdate(float easedTime)
            {
                currentValue = Interpolate(fromValue, toValue, easedTime);
                canvasGroup.alpha = currentValue;
            }
        }
    }
}