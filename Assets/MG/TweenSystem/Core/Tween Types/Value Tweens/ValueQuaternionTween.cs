using System;
using UnityEngine;

namespace MG.TweenSystem
{
    public static class ValueQuaternionTween
    {
        public static Tween<Quaternion> XValue(this Transform transform, Quaternion from, Quaternion to,
            float duration,
            Action<Quaternion> onUpdate) =>
            Tween<Quaternion>.SetUp<TweenType>(transform).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<Quaternion> XValue(this Transform transform, Quaternion to, float duration,
            Action<Quaternion> onUpdate) =>
            Tween<Quaternion>.SetUp<TweenType>(transform).SetOnUpdate(onUpdate).Initialize(duration, to);


        public static Tween<Quaternion> XValue(this GameObject gameObject, Quaternion from, Quaternion to,
            float duration,
            Action<Quaternion> onUpdate) =>
            Tween<Quaternion>.SetUp<TweenType>(gameObject).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<Quaternion> XValue(this GameObject gameObject, Quaternion to, float duration,
            Action<Quaternion> onUpdate) =>
            Tween<Quaternion>.SetUp<TweenType>(gameObject).SetOnUpdate(onUpdate).Initialize(duration, to);


        public static Tween<Quaternion> XValue(this Component component, Quaternion from, Quaternion to,
            float duration,
            Action<Quaternion> onUpdate) =>
            Tween<Quaternion>.SetUp<TweenType>(component).SetOnUpdate(onUpdate).SetFrom(from).Initialize(duration, to);

        public static Tween<Quaternion> XValue(this Component component, Quaternion to, float duration,
            Action<Quaternion> onUpdate) =>
            Tween<Quaternion>.SetUp<TweenType>(component).SetOnUpdate(onUpdate).Initialize(duration, to);

        private class TweenType : Tween<Quaternion>
        {
            private Action<Quaternion> onUpdate;
            public override bool OnInitialize() => true;
            public override Quaternion GetFrom() => Quaternion.identity;

            public override void OnUpdate(float easedTime)
            {
                currentValue = Quaternion.Lerp(fromValue, toValue, easedTime);
                onUpdate?.Invoke(currentValue);
            }

            public Tween<Quaternion> SetOnUpdate(Action<Quaternion> OnUpdate)
            {
                onUpdate = OnUpdate;
                return this;
            }
        }
    }
}