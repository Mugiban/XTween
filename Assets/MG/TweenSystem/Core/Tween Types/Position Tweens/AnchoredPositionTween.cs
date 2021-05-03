using UnityEngine;

namespace MG.TweenSystem
{
    public static class AnchoredPositionTween
    {
        public static Tween<Vector2>
            XAnchoredPosition(this GameObject gameObject, Vector2 from, Vector2 to, float duration) =>
            Tween<Vector2>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector2>
            XAnchoredPosition(this GameObject gameObject, Vector2 to, float duration) =>
            Tween<Vector2>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<Vector2>
            XAnchoredPosition(this Transform transform, Vector2 from, Vector2 to, float duration) =>
            Tween<Vector2>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector2>
            XAnchoredPosition(this Transform transform, Vector2 to, float duration) =>
            Tween<Vector2>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<Vector2>
            XAnchoredPosition(this Component component, Vector2 from, Vector2 to, float duration) =>
            Tween<Vector2>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector2>
            XAnchoredPosition(this Component component, Vector2 to, float duration) =>
            Tween<Vector2>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<Vector2>
        {
            private RectTransform rectTransform;

            public override bool OnInitialize()
            {
                rectTransform = gameObject.GetComponent<RectTransform>();
                return rectTransform != null;
            }

            public override Vector2 GetFrom() => rectTransform.anchoredPosition;

            public override void OnUpdate(float easedTime)
            {
                currentValue.x = Interpolate(fromValue.x, toValue.x, easedTime);
                currentValue.y = Interpolate(fromValue.y, toValue.y, easedTime);
                rectTransform.anchoredPosition = currentValue;
            }
        }
    }
}