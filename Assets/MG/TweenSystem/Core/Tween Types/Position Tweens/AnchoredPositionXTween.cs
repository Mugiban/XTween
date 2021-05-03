using UnityEngine;

namespace MG.TweenSystem
{
    public static class AnchoredPositionXTween
    {
        public static Tween<float>
            XAnchoredPositionX(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAnchoredPositionX(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XAnchoredPositionX(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAnchoredPositionX(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XAnchoredPositionX(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAnchoredPositionX(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private RectTransform rectTransform;
            private Vector2 anchoredPosition;

            public override bool OnInitialize()
            {
                rectTransform = gameObject.GetComponent<RectTransform>();
                return rectTransform != null;
            }

            public override float GetFrom() => rectTransform.anchoredPosition.x;

            public override void OnUpdate(float easedTime)
            {
                anchoredPosition = rectTransform.anchoredPosition;
                currentValue = Interpolate(fromValue, toValue, easedTime);
                anchoredPosition.x = currentValue;
                rectTransform.anchoredPosition = anchoredPosition;
            }
        }
    }
}