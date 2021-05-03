﻿using UnityEngine;

namespace MG.TweenSystem
{
    public static class AudioSourceSpatialBlendTween
    {
        public static Tween<float>
            XAudioSpatialBlend(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAudioSpatialBlend(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XAudioSpatialBlend(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAudioSpatialBlend(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XAudioSpatialBlend(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAudioSpatialBlend(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private AudioSource audioSource;

            public override bool OnInitialize()
            {
                audioSource = gameObject.GetComponent<AudioSource>();
                return audioSource != null;
            }

            public override float GetFrom() => audioSource.spatialBlend;

            public override void OnUpdate(float easedTime)
            {
                currentValue = Interpolate(fromValue, toValue, easedTime);
                audioSource.spatialBlend = currentValue;
            }
        }
    }
}