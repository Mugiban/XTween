using UnityEngine;

namespace MG.TweenSystem
{
    public static class PositionYTween
    {
        public static Tween<float>
            XPositionY(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XPositionY(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XPositionY(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XPositionY(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XPositionY(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XPositionY(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private Vector3 position;
            public override bool OnInitialize() => true;
            public override float GetFrom() => transform.position.y;

            public override void OnUpdate(float easedTime)
            {
                position = transform.position;
                currentValue = Interpolate(fromValue, toValue, easedTime);
                position.y = currentValue;
                transform.position = position;
            }
        }
    }
}