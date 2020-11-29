using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void Initialize()
    {
        this.axe = new Axe(10, 10);
        this.dummy = new Dummy(10, 10);
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
    }

    [Test]
    public void AttackingWithBrokenWeaponShouldThrowAnException()
    {
        axe = new Axe(10, 0);

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}