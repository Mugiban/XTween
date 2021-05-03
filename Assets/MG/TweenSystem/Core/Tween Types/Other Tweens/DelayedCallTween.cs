using System;
using UnityEngine;

namespace MG.TweenSystem
{
    public static class DelayedCallTween
    {
        public static Tween<bool> XDelayedCall(this Transform transform, float duration, Action onComplete) =>
            Tween<bool>.SetUp<TweenType>(transform).SetOnComplete(onComplete).Initialize(duration, false);

        public static Tween<bool> XDelayedCall(this GameObject gameObject, float duration, Action onComplete) =>
            Tween<bool>.SetUp<TweenType>(gameObject).SetOnComplete(onComplete).Initialize(duration, false);
        
        public static Tween<bool> XDelayedCall(this Component component, float duration, Action onComplete) =>
            Tween<bool>.SetUp<TweenType>(component).SetOnComplete(onComplete).Initialize(duration, false);

        private class TweenType : Tween<bool>
        {
            public override bool OnInitialize() => true;

            public override bool GetFrom() => true;

            public override void OnUpdate(float easedTime)
            {
            }
        }
    }
}