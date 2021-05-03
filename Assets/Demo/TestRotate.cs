using MG.TweenSystem;
using UnityEngine;

namespace MG
{
    public class TestRotate : MonoBehaviour
    {
        [SerializeField] [Range(.1f, 5f)] private float duration = 2f;
        [SerializeField] private Ease ease;
        [SerializeField] [Range(-361f, 360f)] private float from;
        [SerializeField] [Range(-361f, 360f)] private float to = 360f;
        private void Start()
        {
            gameObject.XCancelAll();
            gameObject.XRotateLocalZ(from, to, duration).SetEase(ease).SetLoopPingPong(int.MaxValue);
        }
    }
}