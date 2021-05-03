using System;
using UnityEditor;
using UnityEngine;

namespace MG.TweenSystem
{
    public abstract class Tween<TValueType> : MonoBehaviour, ITween
    {
        public static TweenType SetUp<TweenType>(GameObject gameObject) where TweenType : Tween<TValueType> =>
            gameObject.AddComponent<TweenType>();

        public static TweenType SetUp<TweenType>(Transform transform) where TweenType : Tween<TValueType> =>
            transform.gameObject.AddComponent<TweenType>();
        
        public static TweenType SetUp<TweenType>(Component component) where TweenType : Tween<TValueType> =>
            component.gameObject.AddComponent<TweenType>();
        
        
        protected TValueType fromValue;
        
        protected TValueType toValue;
        
        protected TValueType currentValue = default;
        
        
        private Ease ease;
        public Ease Ease => ease;

        private bool didTimeReachEnd;

        private bool overrideFrom;
        
        private bool hasDuration;

        private float duration;

        private bool hasDelay;

        private float delay;
        public float Delay => delay;
        
        private bool useUnscaledTime;

        private bool hasLoopCount;

        private int loopCount;
        
        private bool isInfinite;

        private bool usePingPong;

        private bool isPlayingBackwards;
        
        private bool isPaused;

        private bool goToFirstFrameImmediately;
        
        private bool setToBeDestroyed;
        private bool hasOvershooting;
        private float overshooting;

        private Action OnStart = delegate { };
        
        private Action OnComplete = delegate { };

        private Action OnCancel = delegate { };
        
        
        private float timer;

        //true if all the components required are correctly hooked
        public abstract bool OnInitialize();
        public abstract TValueType GetFrom();
        public abstract void OnUpdate(float easedTime);

        public void Start()
        {
            if (OnInitialize() == false)
                DestroyTween();
            
            
            if (hasDelay == false || goToFirstFrameImmediately)
            {
                if (overrideFrom == false)
                {
                    fromValue = GetFrom();
                }

                OnUpdate(EasingType.Apply(ease, 0));
            }
            
            OnStart?.Invoke();
        }
        
        /// Sets the final values required for the tween can start. When the object
        /// is not active in the hierarchy, it will be decommissioned right away.
        internal Tween<TValueType> Initialize(float duration, TValueType valueTo)
        {
            if (gameObject.activeInHierarchy == false)
                DestroyTween();
            else
            {
                this.duration = duration;
                hasDuration = duration > 0;
                toValue = valueTo;
            }

            return this;
        }

        public Tween<TValueType> SetFrom(TValueType from)
        {
            overrideFrom = true;
            fromValue = from;
            return this;
        }

        private void OnDisable()
        {
            if (didTimeReachEnd == false)
                DestroyTween();
        }
        private void Update()
        {
            
            if (setToBeDestroyed || isPaused)
                return;
            
            if (hasDelay)
            {
                delay -= useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
                if (delay <= 0 == false) return;
                
                hasDelay = false;

                if (overrideFrom == false)
                {
                    fromValue = GetFrom();
                }

                OnUpdate(EasingType.Apply(ease, 0));
            }
            
            else if (hasDuration == false)
            {
                OnUpdate(EasingType.Apply(ease, 1));
                DestroyTween();
            }
            else
            {
                var deltaTime = useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
                var easedTime = deltaTime / duration;
                timer += isPlayingBackwards ? -easedTime : easedTime;
                if (timer > 1)
                {
                    timer = 1;
                    if (usePingPong)
                        isPlayingBackwards = true;
                    else if (isInfinite == false)
                        didTimeReachEnd = true;
                    else
                        timer = 0;
                }
                else if (usePingPong && timer < 0)
                {
                    timer = 0;
                    isPlayingBackwards = false;
                    if (isInfinite == false)
                        didTimeReachEnd = true;
                }

                OnUpdate(EasingType.Apply(ease, timer));
                
                if (didTimeReachEnd)
                    if (hasLoopCount && loopCount > 1)
                    {
                        didTimeReachEnd = false;
                        loopCount -= 1;
                        timer = 0;
                    }
                    else
                    {
                        OnComplete?.Invoke();
                        DestroyTween();
                    }
            }
        }

        private void DestroyTween()
        {
            setToBeDestroyed = true;
            Destroy(this);
        }

        internal float Interpolate(float from, float to, float value)
        {
            if (!hasOvershooting) return from * (1 - value) + to * value;

            if (value > 1)
            {
                value -= (value - 1) / (overshooting + 1);
            }
            else if (timer < 0)
            {
                value -= value / (overshooting + 1);
            }
            
            return from * (1 - value) + to * value;
        }

        public Tween<TValueType> SetOnStart(Action onStart)
        {
            OnStart = onStart;
            return this;
        }
        
        public Tween<TValueType> SetOnComplete(Action onComplete)
        {
            OnComplete = onComplete;
            return this;
        }

        public Tween<TValueType> SetOnCancel(Action onCancel)
        {
            OnCancel = onCancel;
            return this;
        }

        public Tween<TValueType> SetPingPong()
        {
            usePingPong = true;
            return this;
        }

        public Tween<TValueType> SetLoopCount(int count)
        {
            hasLoopCount = true;
            loopCount = count;
            return this;
        }
        
        public Tween<TValueType> SetLoopPingPong(int count)
        {
            usePingPong = true;
            hasLoopCount = true;
            loopCount = count;
            return this;
        }

        public Tween<TValueType> SetInfinite()
        {
            isInfinite = true;
            return this;
        }

        public Tween<TValueType> SetDelay(float newDelay, bool goToFirstFrame = false)
        {
            delay = newDelay;
            hasDelay = true;
            goToFirstFrameImmediately = goToFirstFrame;
            return this;
        }
        
        public Tween<TValueType> SetRandomDuration(float min, float max)
        {
            duration = UnityEngine.Random.Range(min, max);
            duration = Mathf.Max(0, duration);
            return this;
        }
        
        public Tween<TValueType> SetRandomDuration01()
        {
            duration = UnityEngine.Random.Range(0f, 1f);
            return this;
        }

        public Tween<TValueType> SetDuration(float duration)
        {
            this.duration = duration;
            return this;
        }

        public Tween<TValueType> SetPaused(bool paused)
        {
            isPaused = paused;
            return this;
        }

        public Tween<TValueType> SetUseUnscaledTime(bool enable)
        {
            useUnscaledTime = enable;
            return this;
        }

        /// Sets the overshooting of Eases that exceed their boundaries such as
        /// elastic and back.
        public Tween<TValueType> SetOvershooting(float overShooting)
        {
            overshooting = overShooting;
            hasOvershooting = true;
            return this;
        }
        


        public float GetTotalDuration(bool includeDelay = false)
        {
            var totalDuration = duration;
            if (hasLoopCount)
            {
                totalDuration *= loopCount;
            }

            if (usePingPong)
            {
                totalDuration *= 2f;
            }

            if (includeDelay && hasDelay)
            {
                totalDuration += delay;
            }

            return totalDuration;
        }

        public void Cancel()
        {
            OnCancel?.Invoke();
            DestroyTween();
        }
        public Tween<TValueType> SetEase(Ease easeType)
        {
            ease = easeType;
            return this;
        }
    }
}