using UnityEngine;
using UnityEngine.UI;

namespace MG.TweenSystem
{
    public static class ImageFillAmountTween
    {
        public static Tween<float>
            XFillAmount(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XFillAmount(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XFillAmount(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XFillAmount(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XFillAmount(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XFillAmount(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private Image image;

            public override bool OnInitialize()
            {
                image = gameObject.GetComponent<Image>();
                return image != null;
            }

            public override float GetFrom() => image.fillAmount;

            public override void OnUpdate(float easedTime)
            {
                currentValue = Interpolate(fromValue, toValue, easedTime);
                image.fillAmount = currentValue;
            }
        }
    }
}