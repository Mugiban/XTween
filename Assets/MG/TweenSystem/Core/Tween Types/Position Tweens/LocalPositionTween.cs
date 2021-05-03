using UnityEngine;

namespace MG.TweenSystem
{
    public static class LocalPositionTween
    {
        public static Tween<Vector3>
            XLocalPosition(this GameObject gameObject, Vector3 from, Vector3 to, float duration) =>
            Tween<Vector3>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector3>
            XLocalPosition(this GameObject gameObject, Vector3 to, float duration) =>
            Tween<Vector3>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<Vector3>
            XLocalPosition(this Transform transform, Vector3 from, Vector3 to, float duration) =>
            Tween<Vector3>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector3>
            XLocalPosition(this Transform transform, Vector3 to, float duration) =>
            Tween<Vector3>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<Vector3>
            XLocalPosition(this Component component, Vector3 from, Vector3 to, float duration) =>
            Tween<Vector3>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<Vector3>
            XLocalPosition(this Component component, Vector3 to, float duration) =>
            Tween<Vector3>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<Vector3>
        {
            public override bool OnInitialize() => true;
            public override Vector3 GetFrom() => transform.localPosition;

            public override void OnUpdate(float easedTime)
            {
                currentValue.x = Interpolate(fromValue.x, toValue.x, easedTime);
                currentValue.y = Interpolate(fromValue.y, toValue.y, easedTime);
                currentValue.z = Interpolate(fromValue.z, toValue.z, easedTime);
                transform.localPosition = currentValue;
            }
        }
    }
}