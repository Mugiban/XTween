using UnityEngine;

namespace MG.TweenSystem
{
    public static class EulerAnglesZTween
    {
        public static Tween<float>
            XRotateZ(this GameObject gameObject, float from, float to, float dion) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(dion, to);

        public static Tween<float>
            XRotateZ(this GameObject gameObject, float to, float dion) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(dion, to);


        public static Tween<float>
            XRotateZ(this Transform transform, float from, float to, float dion) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(dion, to);

        public static Tween<float>
            XRotateZ(this Transform transform, float to, float dion) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(dion, to);


        public static Tween<float>
            XRotateZ(this Component component, float from, float to, float dion) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(dion, to);

        public static Tween<float>
            XRotateZ(this Component component, float to, float dion) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(dion, to);

        private class TweenType : Tween<float>
        {
            private Quaternion quaternionValueFrom;
            private Quaternion quaternionValueTo;
            public override bool OnInitialize() => true;
            public override float GetFrom() => transform.eulerAngles.z;

            public override void OnUpdate(float easedTime)
            {
                quaternionValueFrom = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y,
                    fromValue);
                quaternionValueTo = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y,
                    toValue);
                transform.rotation = Quaternion.Lerp(quaternionValueFrom, quaternionValueTo, easedTime);
            }
        }
    }
}