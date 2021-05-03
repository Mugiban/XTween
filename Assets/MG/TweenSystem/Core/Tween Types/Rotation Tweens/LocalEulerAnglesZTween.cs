using UnityEngine;

namespace MG.TweenSystem
{
    public static class LocalEulerAnglesZTween
    {
        public static Tween<float>
            XRotateLocalZ(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XRotateLocalZ(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XRotateLocalZ(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XRotateLocalZ(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XRotateLocalZ(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XRotateLocalZ(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private Quaternion quaternionValueFrom;
            private Quaternion quaternionValueTo;
            public override bool OnInitialize() => true;
            public override float GetFrom() => transform.localEulerAngles.z;

            public override void OnUpdate(float easedTime)
            {
                quaternionValueFrom =
                    Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, fromValue);
                quaternionValueTo =
                    Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, toValue);
                transform.localRotation = Quaternion.Lerp(quaternionValueFrom, quaternionValueTo, easedTime);
            }
        }
    }
}