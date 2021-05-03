using MG.TweenSystem;
using UnityEngine;

namespace MG
{
    public class TestScale : MonoBehaviour
    {
        [SerializeField] [Range(.1f, 5f)] private float duration = 2f;
        [SerializeField] private Ease ease;
        [SerializeField] [Range(1, 5)] private int from = 1;
        [SerializeField] [Range(1, 5)] private int to = 3;

        private void Start()
        {
            gameObject.XLocalScale(from, to, duration).SetEase(ease).SetPingPong().SetLoopCount(int.MaxValue)
                .SetDelay(.5f);

            gameObject.XSpriteColor(Color.white, Color.red, duration).SetPingPong().SetLoopCount(int.MaxValue);
        }
    }
}