using System.Collections;
using MG.TweenSystem;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ValueTweenTests
{

    private GameObject fakeGameObject;
    private float simpleDuration;

    [SetUp]
    public void Init()
    {
        fakeGameObject = new GameObject();
        simpleDuration = .25f;
    }
    
    [TestCase(1, 0, ExpectedResult = null)]
    [TestCase(546, 1234, ExpectedResult =  null)]
    [TestCase(0, -1, ExpectedResult =  null)]
    [TestCase(0, 1, ExpectedResult =  null)]
    public IEnumerator ValueInterpolateCorrectlyWithFloat(float expected, float actual)
    {
        fakeGameObject.XValue(expected, simpleDuration, value => { actual = value; });
        
        
        yield return new WaitForSeconds(simpleDuration);

        Assert.AreEqual(expected, actual);
    }
    
    [UnityTest]
    public IEnumerator ValueInterpolateCorrectlyWithColor()
    {
        var actual = Color.white;
        var expected = Color.black;
        
        Assert.AreNotEqual(expected, actual);
        
        fakeGameObject.XValue(expected, simpleDuration, color => { actual = color; });
        
        
        yield return new WaitForSeconds(simpleDuration);

        Assert.AreEqual(expected, actual);
    }
    
    [UnityTest]
    public IEnumerator ValueInterpolateCorrectlyWithVector2()
    {
        var actual = Vector2.zero;
        var expected = Vector2.one;
        
        Assert.AreNotEqual(expected, actual);
        
        fakeGameObject.XValue(expected, simpleDuration, vector2 => { actual = vector2; });
        
        
        yield return new WaitForSeconds(simpleDuration);

        Assert.AreEqual(expected, actual);
    }
    
    [UnityTest]
    public IEnumerator ValueInterpolateCorrectlyWithVector3()
    {
        var actual = Vector3.zero;
        var expected = Vector3.one;
        
        Assert.AreNotEqual(expected, actual);
        
        fakeGameObject.XValue(expected, simpleDuration, vector3 => { actual = vector3; });
        
        
        yield return new WaitForSeconds(simpleDuration);

        Assert.AreEqual(expected, actual);
    }
    
    [UnityTest]
    public IEnumerator ValueInterpolateCorrectlyWithQuaternion()
    {
        var actual = Quaternion.identity;
        var expected = Quaternion.Euler(0, 180, 0);
        
        Assert.AreNotEqual(expected, actual);
        
        fakeGameObject.XValue(expected, simpleDuration, quaternion => { actual = quaternion; });
        
        
        yield return new WaitForSeconds(simpleDuration);

        Assert.AreEqual(expected, actual);
    }

}
