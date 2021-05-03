using UnityEngine;

namespace MG.TweenSystem
{
    public static class LocalScaleYTween
    {
        public static Tween<float>
            XLocalScaleY(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalScaleY(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XLocalScaleY(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalScaleY(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XLocalScaleY(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalScaleY(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private Vector3 localScale;
            public override bool OnInitialize() => true;
            public override float GetFrom() => transform.localScale.y;

            public override void OnUpdate(float easedTime)
            {
                localScale = transform.localScale;
                currentValue = Interpolate(fromValue, toValue, easedTime);
                localScale.y = currentValue;
                transform.localScale = localScale;
            }
        }
    }
}