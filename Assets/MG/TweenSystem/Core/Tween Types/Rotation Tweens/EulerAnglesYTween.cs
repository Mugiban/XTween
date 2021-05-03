using UnityEngine;

namespace MG.TweenSystem
{
    public static class EulerAnglesYTween
    {
        public static Tween<float>
            XRotateY(this GameObject gameObject, float from, float to, float dion) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(dion, to);

        public static Tween<float>
            XRotateY(this GameObject gameObject, float to, float dion) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(dion, to);


        public static Tween<float>
            XRotateY(this Transform transform, float from, float to, float dion) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(dion, to);

        public static Tween<float>
            XRotateY(this Transform transform, float to, float dion) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(dion, to);


        public static Tween<float>
            XRotateY(this Component component, float from, float to, float dion) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(dion, to);

        public static Tween<float>
            XRotateY(this Component component, float to, float dion) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(dion, to);

        private class TweenType : Tween<float>
        {
            private Quaternion quaternionValueFrom;
            private Quaternion quaternionValueTo;
            public override bool OnInitialize() => true;
            public override float GetFrom() => transform.eulerAngles.y;

            public override void OnUpdate(float easedTime)
            {
                quaternionValueFrom = Quaternion.Euler(transform.eulerAngles.x, fromValue,
                    transform.eulerAngles.z);
                quaternionValueTo = Quaternion.Euler(transform.eulerAngles.x, toValue,
                    transform.eulerAngles.z);
                transform.rotation = Quaternion.Lerp(quaternionValueFrom, quaternionValueTo, easedTime);
            }
        }
    }
}