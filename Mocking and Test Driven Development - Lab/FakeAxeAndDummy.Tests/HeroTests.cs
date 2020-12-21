using FakeAxeAndDummy.Contracts;
using FakeAxeAndDummy.Tests.Fakes;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void GivenHero_ShouldReceiveExperience_WhenAttackedTargetDies()
    {
        
        Mock<ITarget> fakeTarget = new Mock<ITarget>();

        fakeTarget.Setup(f => f.GiveExperience()).Returns(20);
        fakeTarget.Setup(f => f.IsDead()).Returns(true); 

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Hero hero = new Hero("Pesho", fakeWeapon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.AreEqual(20, hero.Experience);
    }
}