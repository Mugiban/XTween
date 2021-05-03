using System.Collections;
using MG.TweenSystem;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TweenTests
{
    private GameObject fakeGameObject;
    private float simpleDuration;

    [SetUp]
    public void Init()
    {
        fakeGameObject = new GameObject();
        simpleDuration = .25f;
    }
    
    [UnityTest]
    public IEnumerator OnStartIsCalled()
    {
        var tween = fakeGameObject.XTestTween(simpleDuration);

        var actual = false;
        tween.SetOnStart(() => actual = true);
        Assert.AreNotEqual(true, actual);
        yield return new WaitForSeconds(simpleDuration);

        Assert.AreEqual(true, actual);
    }
    
    [UnityTest]
    public IEnumerator OnCompleteIsCalled()
    {
        var tween = fakeGameObject.XTestTween(simpleDuration);

        var actual = false;
        tween.SetOnComplete(() => actual = true);
        Assert.AreNotEqual(true, actual);
        yield return new WaitForSeconds(simpleDuration);

        Assert.AreEqual(true, actual);
    }
    
    [UnityTest]
    public IEnumerator SetDurationCorrectly()
    {
        var expected = 1f;
        var tween = fakeGameObject.XTestTween(expected);
        var actual = tween.GetTotalDuration();

        yield return new WaitForSeconds(expected);

        Assert.AreEqual(expected, actual);
    }
    
    [UnityTest]
    public IEnumerator SetEaseCorrectly()
    {
        var expected = Ease.EaseInBounce;
        var tween = fakeGameObject.XTestTween(simpleDuration);
        
        tween.SetEase(expected);
        
        var actual = tween.Ease;
        yield return new WaitForSeconds(simpleDuration);

        Assert.AreEqual(expected, actual);
    }
    
    [UnityTest]
    public IEnumerator SetDelayCorrectly()
    {
        var expected = 1f;
        var tween = fakeGameObject.XTestTween(simpleDuration);
        
        tween.SetDelay(expected);
        
        var actual = tween.Delay;
        yield return new WaitForSeconds(simpleDuration);

        Assert.AreEqual(expected, actual);
    }
}
