using UnityEngine;

namespace MG.TweenSystem
{
    public static class LocalScaleZTween
    {
        public static Tween<float>
            XLocalScaleZ(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalScaleZ(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XLocalScaleZ(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalScaleZ(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XLocalScaleZ(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalScaleZ(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private Vector3 localScale;
            public override bool OnInitialize() => true;
            public override float GetFrom() => transform.localScale.z;

            public override void OnUpdate(float easedTime)
            {
                localScale = transform.localScale;
                currentValue = Interpolate(fromValue, toValue, easedTime);
                localScale.z = currentValue;
                transform.localScale = localScale;
            }
        }
    }
}