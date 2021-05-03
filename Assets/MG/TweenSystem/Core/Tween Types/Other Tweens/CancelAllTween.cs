using UnityEngine;

namespace MG.TweenSystem
{
    public static class CancelAllTween
    {
        public static void XCancelAll(this Component component, bool includeChildren = false,
            bool includeInactive = false) =>
            component.gameObject.XCancelAll(includeChildren, includeInactive);

        public static void XCancelAll(this Transform transform, bool includeChildren = false,
            bool includeInactive = false) =>
            transform.gameObject.XCancelAll(includeChildren, includeInactive);

        public static void XCancelAll(this GameObject gameObject, bool includeChildren = false,
            bool includeInactive = false)
        {
            var tweens = includeChildren
                ? gameObject.GetComponentsInChildren<ITween>(includeInactive)
                : gameObject.GetComponents<ITween>();
            foreach (var tween in tweens)
                tween.Cancel();
        }
    }
}