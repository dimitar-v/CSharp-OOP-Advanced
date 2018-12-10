using NUnit.Framework;
using System;

namespace Tests
{
    public class AxeTest
    {
        private Axe axe;
        private Dummy dummy;

        //[SetUp]
        public void Setup(int durability)
        {
            //Arrange
            axe = new Axe(10, durability);
            dummy = new Dummy(10, 10);
        }

        //•	Test if weapon loses durability after each attack
        [TestCase(10)]
        [TestCase(10000)]
        [TestCase(5)]
        public void TestWeaponLoseDurabilityAfterAttack(int durabilityPoints)
        {
            //Arrange
            Setup(durabilityPoints);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.AreEqual(--durabilityPoints, axe.DurabilityPoints, "Weapon not loses durability after attack.");
        }

        //•	Test attacking with a broken weapon
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void TestAttackingWithBrokenWapon(int durability)
        {
            Setup(durability);

            string expectedMessage = "Axe is broken.";

            var exception = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Not throw InvalidOperationException");
            Assert.AreEqual(expectedMessage, exception.Message, "Not correct exception message.");

            //Assert.Throws(typeof(InvalidOperationException), () => axe.Attack(dummy));

            //Assert.That(
            //    () => axe.Attack(dummy),
            //    Throws.InvalidOperationException.With.Message.EqualTo(expectedMessage),
            //    "Not throw InvalidOperationException or not correct message.");
        }
    }
}