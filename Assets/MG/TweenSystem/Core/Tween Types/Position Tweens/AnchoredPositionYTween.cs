using UnityEngine;

namespace MG.TweenSystem
{
    public static class AnchoredPositionYTween
    {
        public static Tween<float>
            XAnchoredPositionY(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAnchoredPositionY(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XAnchoredPositionY(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAnchoredPositionY(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XAnchoredPositionY(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAnchoredPositionY(this Component component, float to, float duration) =>
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

            public override float GetFrom() => rectTransform.anchoredPosition.y;

            public override void OnUpdate(float easedTime)
            {
                anchoredPosition = rectTransform.anchoredPosition;
                currentValue = Interpolate(fromValue, toValue, easedTime);
                anchoredPosition.y = currentValue;
                rectTransform.anchoredPosition = anchoredPosition;
            }
        }
    }
}