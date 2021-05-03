using UnityEngine;

namespace MG.TweenSystem
{
    public static class MaterialAlphaTween
    {
        public static Tween<float>
            XAlpha(this MeshRenderer meshRenderer, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(meshRenderer).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XAlpha(this MeshRenderer meshRenderer, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(meshRenderer).Initialize(duration, to);

        
        public static Tween<float>
            XMaterialAlpha(this GameObject gameObject, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XMaterialAlpha(this GameObject gameObject, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<float>
            XMaterialAlpha(this Transform transform, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XMaterialAlpha(this Transform transform, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<float>
            XMaterialAlpha(this Component component, float from, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<float>
            XMaterialAlpha(this Component component, float to, float duration) =>
            Tween<float>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<float>
        {
            private MeshRenderer meshRenderer;
            private Material material;
            private Color color;

            public override bool OnInitialize()
            {
                meshRenderer = gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                    material = meshRenderer.material;
                return meshRenderer != null;
            }

            public override float GetFrom() => material.color.a;

            public override void OnUpdate(float easedTime)
            {
                color = material.color;
                currentValue = Interpolate(fromValue, toValue, easedTime);
                color.a = currentValue;
                material.color = color;
            }
        }
    }
}