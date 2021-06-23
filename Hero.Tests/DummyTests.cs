using NUnit.Framework;
using System;

namespace Hero.Tests
{
    [TestFixture]
    public class DummyTests
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
        public void TakeAttack_DummyLosesHealthAfterAttack()
        {
            dummy.TakeAttack(axe.AttackPoints);

            Assert.AreEqual(18, dummy.Health, "Dummy Health doesn't change after attack");
        }

        [Test]
        public void TakeAttack_DeadDummyIsAttackad_ShouldThrowInvalidOperationException()
        {
            Dummy dummy = new Dummy(0, 10);

            var ex = Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(axe.AttackPoints));
            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
        }
        [Test]
        public void GiveExperience_DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(-1, 10);
            var exp = dummy.GiveExperience();
            Assert.AreEqual(10, exp, "Dead Dummy do not give experience.");
        }
        [Test]
        public void GiveExperience_AliveDummyCanNotGiveXP()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
            Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
        }
    }
}
