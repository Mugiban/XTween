using UnityEngine;

namespace MG.TweenSystem
{
    public static class LocalPositionXTween
    {
        public static Tween<float>
            XLocalPositionX(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalPositionX(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XLocalPositionX(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalPositionX(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XLocalPositionX(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalPositionX(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private Vector3 localPosition;
            public override bool OnInitialize() => true;
            public override float GetFrom() => transform.localPosition.x;

            public override void OnUpdate(float easedTime)
            {
                localPosition = transform.localPosition;
                currentValue = Interpolate(fromValue, toValue, easedTime);
                localPosition.x = currentValue;
                transform.localPosition = localPosition;
            }
        }
    }
}