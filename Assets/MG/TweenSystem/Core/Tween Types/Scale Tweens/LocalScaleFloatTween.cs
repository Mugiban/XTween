using UnityEngine;

namespace MG.TweenSystem
{
    public static class LocalScaleFloatTween
    {
        public static Tween<float>
            XLocalScale(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XLocalScale(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XLocalScale(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to).SetFrom(from);

        public static Tween<float>
            XLocalScale(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XLocalScale(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to).SetFrom(from);

        public static Tween<float>
            XLocalScale(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);
        

        private class TweenType : Tween<float>
        {
            public override bool OnInitialize() => true;
            public override float GetFrom() => 1;

            public override void OnUpdate(float easedTime)
            {
                currentValue = Interpolate(fromValue, toValue, easedTime);
                transform.localScale = new Vector3(currentValue, currentValue, currentValue);
            }
        }
    }
}