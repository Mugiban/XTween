using UnityEngine;

namespace MG.TweenSystem
{
    public static class LocalPositionZTween
    {
        public static Tween<float>
            XLocalPositionZ(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalPositionZ(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XLocalPositionZ(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalPositionZ(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XLocalPositionZ(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalPositionZ(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private Vector3 localPosition;
            public override bool OnInitialize() => true;
            public override float GetFrom() => transform.localPosition.z;

            public override void OnUpdate(float easedTime)
            {
                localPosition = transform.localPosition;
                currentValue = Interpolate(fromValue, toValue, easedTime);
                localPosition.z = currentValue;
                transform.localPosition = localPosition;
            }
        }
    }
}