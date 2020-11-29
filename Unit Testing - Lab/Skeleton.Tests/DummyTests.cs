using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;

    [SetUp]
    public void Initialize()
    {
        this.dummy = new Dummy(10, 10);
    }

    [Test]
    public void DummyShouldLoseHealthIfAttacked()
    {
        dummy.TakeAttack(2);
        int expectedResult = 8;

        Assert.AreEqual(expectedResult, dummy.Health);
    }

    [Test]
    public void DeadDummyShouldThrowExceptionWhenAttacked()
    {
        dummy = new Dummy(0, 10);

        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
    }

    [Test]
    public void DeadDummyShouldGiveXP()
    {
        dummy = new Dummy(0, 10);

        int expectedResult = 10;
        int actualResult = dummy.GiveExperience();

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void AliveDummyShouldNotGiveXP()
    {
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
