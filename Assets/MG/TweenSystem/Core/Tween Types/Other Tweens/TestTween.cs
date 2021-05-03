using UnityEngine;

namespace MG.TweenSystem
{
    public static class TestTween
    {
        public static Tween<bool> XTestTween(this Transform transform, float duration) =>
            Tween<bool>.SetUp<TweenType>(transform).Initialize(duration, false);
        public static Tween<bool> XTestTween(this GameObject gameObject, float duration) =>
            Tween<bool>.SetUp<TweenType>(gameObject).Initialize(duration, false);
        
        public static Tween<bool> XTestTween(this Component component, float duration) =>
            Tween<bool>.SetUp<TweenType>(component).Initialize(duration, false);

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