using UnityEngine;

namespace MG.TweenSystem
{
    public static class EulerAnglesTween
    {
        public static Tween<Vector3>
            XRotate(this GameObject gameObject, Vector3 from, Vector3 to, float duration) =>
            Tween<Vector3>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector3>
            XRotate(this GameObject gameObject, Vector3 to, float duration) =>
            Tween<Vector3>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<Vector3>
            XRotate(this Transform transform, Vector3 from, Vector3 to, float duration) =>
            Tween<Vector3>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to).SetFrom(from);

        public static Tween<Vector3>
            XRotate(this Transform transform, Vector3 to, float duration) =>
            Tween<Vector3>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<Vector3>
            XRotate(this Component component, Vector3 from, Vector3 to, float duration) =>
            Tween<Vector3>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to).SetFrom(from);

        public static Tween<Vector3>
            XRotate(this Component component, Vector3 to, float duration) =>
            Tween<Vector3>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<Vector3>
        {
            private Quaternion valueFrom;
            private Quaternion valueTo;

            public override bool OnInitialize()
            {
                valueTo = Quaternion.Euler(toValue);
                return true;
            }

            public override Vector3 GetFrom()
            {
                var from = transform.eulerAngles;
                valueFrom = Quaternion.Euler(from);
                return from;
            }

            public override void OnUpdate(float easedTime)
            {
                if (easedTime <= 0)
                    transform.rotation = valueFrom;
                else if (easedTime >= 1)
                    transform.rotation = valueTo;
                else
                    transform.rotation = Quaternion.Lerp(valueFrom, valueTo, easedTime);
            }
        }
    }
}