using System;
using MG.TweenSystem;
using UnityEngine;

namespace MG
{
    public class TestAlpha : MonoBehaviour
    {
        [SerializeField] [Range(.1f, 5f)] private float duration = 2f;
        [SerializeField] private Ease ease;
        [SerializeField] [Range(0f, 1f)] private float from = 0f;
        [SerializeField] [Range(0f, 1f)] private float to = 1f;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            spriteRenderer.XAlpha(from, to, duration).SetEase(ease).SetLoopPingPong(Int32.MaxValue);
        }
    }
}