using NUnit.Framework;
using System;

namespace Hero.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttack = 2;
        private const int AxeDurability = 2;
        private const int DummyHealth = 20;
        private const int DummyXp = 20;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyXp);
        }

        [Test]
        public void Attack_AxeLosesDurabilyAfterAttack()
        {
            axe.Attack(dummy);

            Assert.AreEqual(axe.DurabilityPoints, AxeDurability - 1, "Axe Durability doesn't change after attack");
        }

        [Test]
        public void Attack_AttackWithBrokenAxe_ShouldThrowInvalidOperationException()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
        }
    }
}