using MG.TweenSystem;
using UnityEngine;

namespace MG
{
    public class TestMove : MonoBehaviour
    {
        [SerializeField] [Range(.1f, 5f)] private float duration = 2f;
        [SerializeField] private Ease ease;
        [SerializeField] [Range(-10, 10)] private int from = -7;
        [SerializeField] [Range(-10, 10)] private int to = 7;

        private void Start()
        {
            gameObject.XPositionX(from, to, duration).SetEase(ease).SetPingPong().SetLoopCount(int.MaxValue)
                .SetDelay(.5f);
        }
    }
}