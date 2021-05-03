using UnityEngine;

namespace MG.TweenSystem
{
    public static class MaterialColorTween
    {
        public static Tween<Color>
            XColor(this MeshRenderer meshRenderer, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(meshRenderer).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XColor(this MeshRenderer meshRenderer, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(meshRenderer).Initialize(duration, to);
        
        
        public static Tween<Color>
            XMaterialColor(this GameObject gameObject, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(gameObject).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XMaterialColor(this GameObject gameObject, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(gameObject).Initialize(duration, to);


        public static Tween<Color>
            XMaterialColor(this Transform transform, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(transform).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XMaterialColor(this Transform transform, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(transform).Initialize(duration, to);


        public static Tween<Color>
            XMaterialColor(this Component component, Color from, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(component).SetFrom(from).Initialize(duration, to);

        public static Tween<Color>
            XMaterialColor(this Component component, Color to, float duration) =>
            Tween<Color>.SetUp<TweenType>(component).Initialize(duration, to);

        private class TweenType : Tween<Color>
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

            public override Color GetFrom() => material.color;

            public override void OnUpdate(float easedTime)
            {
                color = material.color;
                currentValue.r = Interpolate(fromValue.r, toValue.r, easedTime);
                currentValue.g = Interpolate(fromValue.g, toValue.g, easedTime);
                currentValue.b = Interpolate(fromValue.b, toValue.b, easedTime);
                currentValue.a = Interpolate(fromValue.a, toValue.a, easedTime);
                color = currentValue;
                material.color = color;
            }
        }
    }
}