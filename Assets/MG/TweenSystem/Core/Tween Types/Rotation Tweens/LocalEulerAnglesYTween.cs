using UnityEngine;

namespace MG.TweenSystem
{
    public static class LocalEulerAnglesYTween
    {
        public static Tween<float>
            XRotateLocalY(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XRotateLocalY(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XRotateLocalY(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XRotateLocalY(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XRotateLocalY(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XRotateLocalY(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private Quaternion quaternionValueFrom;
            private Quaternion quaternionValueTo;
            public override bool OnInitialize() => true;
            public override float GetFrom() => transform.localEulerAngles.y;

            public override void OnUpdate(float easedTime)
            {
                quaternionValueFrom =
                    Quaternion.Euler(transform.localEulerAngles.x, fromValue, transform.localEulerAngles.z);
                quaternionValueTo =
                    Quaternion.Euler(transform.localEulerAngles.x, toValue, transform.localEulerAngles.z);
                transform.localRotation = Quaternion.Lerp(quaternionValueFrom, quaternionValueTo, easedTime);
            }
        }
    }
}