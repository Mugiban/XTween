using UnityEngine;

namespace MG.TweenSystem
{
    public static class EasingType
    {
        private const float A = 1.70158f;
        private const float B = A * 1.525f;
        private const float C = A + 1f;
        private const float D = 2f * Mathf.PI / 3f;
        private const float E = 2f * Mathf.PI / 4.5f;
        private const float F = 7.5625f;
        private const float G = 2.75f;

        public static float Apply(Ease ease, float time)
        {
            switch (ease)
            {
                case Ease.Linear:
                    return Linear(time);
                case Ease.EaseInSine:
                    return InSine(time);
                case Ease.EaseOutSine:
                    return OutSine(time);
                case Ease.EaseInOutSine:
                    return InOutSine(time);
                case Ease.EaseInQuad:
                    return InQuad(time);
                case Ease.EaseOutQuad:
                    return OutQuad(time);
                case Ease.EaseInOutQuad:
                    return InOutQuad(time);
                case Ease.EaseInCubic:
                    return InCubic(time);
                case Ease.EaseOutCubic:
                    return OutCubic(time);
                case Ease.EaseInOutCubic:
                    return InOutCubic(time);
                case Ease.EaseInQuart:
                    return InQuart(time);
                case Ease.EaseOutQuart:
                    return OutQuart(time);
                case Ease.EaseInOutQuart:
                    return InOutQuart(time);
                case Ease.EaseInQuint:
                    return InQuint(time);
                case Ease.EaseOutQuint:
                    return OutQuint(time);
                case Ease.EaseInOutQuint:
                    return InOutQuint(time);
                case Ease.EaseInExpo:
                    return InExpo(time);
                case Ease.EaseOutExpo:
                    return OutExpo(time);
                case Ease.EaseInOutExpo:
                    return InOutExpo(time);
                case Ease.EaseInCirc:
                    return InCirc(time);
                case Ease.EaseOutCirc:
                    return OutCirc(time);
                case Ease.EaseInOutCirc:
                    return InOutCirc(time);
                case Ease.EaseInBack:
                    return InBack(time);
                case Ease.EaseOutBack:
                    return OutBack(time);
                case Ease.EaseInOutBack:
                    return InOutBack(time);
                case Ease.EaseInElastic:
                    return InElastic(time);
                case Ease.EaseOutElastic:
                    return OutElastic(time);
                case Ease.EaseInOutElastic:
                    return InOutElastic(time);
                case Ease.EaseInBounce:
                    return InBounce(time);
                case Ease.EaseOutBounce:
                    return OutBounce(time);
                case Ease.EaseInOutBounce:
                    return InOutBounce(time);
                default:
                    return 0;
            }
        }

        private static float Linear(float time)
        {
            return time;
        }

        private static float InSine(float time)
        {
            return 1f - Mathf.Cos((time * Mathf.PI) / 2f);
        }

        private static float OutSine(float time)
        {
            return Mathf.Sin((time * Mathf.PI) / 2f);
        }

        private static float InOutSine(float time)
        {
            return -(Mathf.Cos(Mathf.PI * time) - 1f) / 2f;
        }

        private static float InQuad(float time)
        {
            return time * time;
        }

        private static float OutQuad(float time)
        {
            return 1 - (1 - time) * (1 - time);
        }

        private static float InOutQuad(float time)
        {
            return time < .5f ? 2 * time * time : 1 - Mathf.Pow(-2 * time + 2, 2) / 2;
        }

        private static float InCubic(float time)
        {
            return time * time * time;
        }

        private static float OutCubic(float time)
        {
            return 1 - Mathf.Pow(1 - time, 3);
        }

        private static float InOutCubic(float time)
        {
            return time < .5f ? 4 * time * time * time : 1 - Mathf.Pow(-2 * time + 2, 3) / 2;
        }

        private static float InQuart(float time)
        {
            return time * time * time * time;
        }

        private static float OutQuart(float time)
        {
            return 1 - Mathf.Pow(1 - time, 4);
        }

        private static float InOutQuart(float time)
        {
            return time < .5f ? 8 * time * time * time * time : 1 - Mathf.Pow(-2 * time + 2, 4) / 2;
        }

        private static float InQuint(float time)
        {
            return time * time * time * time * time;
        }

        private static float OutQuint(float time)
        {
            return 1 - Mathf.Pow(1 - time, 5);
        }

        private static float InOutQuint(float time)
        {
            return time < .5f ? 16 * time * time * time * time * time : 1 - Mathf.Pow(-2 * time + 2, 5) / 2;
        }

        private static float InExpo(float time)
        {
            return time == 0 ? 0 : Mathf.Pow(2, 10 * time - 10);
        }

        private static float OutExpo(float time)
        {
            return time >= 1 ? 1 : 1 - Mathf.Pow(2, -10 * time);
        }

        private static float InOutExpo(float time)
        {
            return time == 0 ? 0 :
                time >= 1 ? 1 :
                time < .5f ? Mathf.Pow(2, 20 * time - 10) / 2 : (2 - Mathf.Pow(2, -20 * time + 10)) / 2;
        }

        private static float InCirc(float time)
        {
            return 1 - Mathf.Sqrt(1 - Mathf.Pow(time, 2));
        }

        private static float OutCirc(float time)
        {
            return Mathf.Sqrt(1 - Mathf.Pow(time - 1, 2));
        }

        private static float InOutCirc(float time)
        {
            return time < .5f
                ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * time, 2))) / 2
                : (Mathf.Sqrt(1 - Mathf.Pow(-2 * time + 2, 2)) + 1) / 2;
        }

        private static float InBack(float time)
        {
            return C * time * time * time - A * time * time;
        }

        private static float OutBack(float time)
        {
            return 1f + C * Mathf.Pow(time - 1, 3) + A * Mathf.Pow(time - 1, 2);
        }

        private static float InOutBack(float time)
        {
            return time < .5f
                ? (Mathf.Pow(2 * time, 2) * ((B + 1) * 2 * time - B)) / 2
                : (Mathf.Pow(2 * time - 2, 2) * ((B + 1) * (time * 2 - 2) + B) + 2) / 2;
        }

        private static float InElastic(float time)
        {
            return time == 0 ? 0 :
                time >= 1 ? 1 : -Mathf.Pow(2, 10 * time - 10) * Mathf.Sin((time * 10f - 10.75f) * D);
        }

        private static float OutElastic(float time)
        {
            return time == 0 ? 0 :
                time >= 1 ? 1 : Mathf.Pow(2, -10 * time) * Mathf.Sin((time * 10 - .75f) * D) + 1;
        }

        private static float InOutElastic(float time)
        {
            return time == 0 ? 0 :
                time >= 1 ? 1 :
                time < .5f ? -(Mathf.Pow(2, 20 * time - 10) * Mathf.Sin((20 * time - 11.125f) * E)) / 2 :
                (Mathf.Pow(2, -20 * time + 10) * Mathf.Sin((20 * time - 11.125f) * E)) / 2 + 1;
        }

        private static float InBounce(float time)
        {
            return 1 - OutBounce(1 - time);
        }

        private static float OutBounce(float time)
        {
            if (time < 1 / G)
                return F * time * time;
            if (time < 2 / G)
                return F * (time -= 1.5f / G) * time + .75f;
            if (time < 2.5f / G)
                return F * (time -= 2.25f / G) * time + .9375f;

            return F * (time -= 2.625f / G) * time + .984375f;
        }

        private static float InOutBounce(float time)
        {
            return time < .5f ? (1 - OutBounce(1 - 2 * time)) / 2 : (1 + OutBounce(2 * time - 1)) / 2;
        }
    }
}