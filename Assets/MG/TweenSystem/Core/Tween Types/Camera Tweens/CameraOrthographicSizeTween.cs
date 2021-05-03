using UnityEngine;

namespace MG.TweenSystem
{
    public static class CameraOrthographicSizeTween
    {
        public static Tween<float>
            XCameraOrthographicSize(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XCameraOrthographicSize(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XCameraOrthographicSize(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XCameraOrthographicSize(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XCameraOrthographicSize(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XCameraOrthographicSize(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private new Camera camera;

            public override bool OnInitialize()
            {
                camera = gameObject.GetComponent<Camera>();
                return camera != null;
            }

            public override float GetFrom() => camera.orthographicSize;

            public override void OnUpdate(float easedTime)
            {
                currentValue = Interpolate(fromValue, toValue, easedTime);
                camera.orthographicSize = currentValue;
            }
        }
    }
}