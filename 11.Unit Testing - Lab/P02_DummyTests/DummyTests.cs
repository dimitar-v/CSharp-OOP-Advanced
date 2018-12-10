using NUnit.Framework;
using System;

namespace Tests
{
    public class DummyTests
    {
        private Dummy dummy;

        //[SetUp]
        public void Setup(int health, int experience)
        {
            dummy = new Dummy(health, experience);
        }

        //•	Dummy loses health if attacked
        [TestCase(10, 10, 10)]
        [TestCase(100, 10, 15)]
        [TestCase(1, 10, 10)]
        public void TestDummyLosesHealthIfAttacked(int health, int experience, int attackPoints)
        {
            Setup(health, experience);

            dummy.TakeAttack(attackPoints);

            Assert.AreEqual(health - attackPoints, dummy.Health, "Dummy not loses health if attacked.");
        }

        //•	Dead Dummy throws an exception if attacked
        [TestCase(0, 10, 10)]
        [TestCase(-10, 10, 15)]
        [TestCase(-1, 10, 10)]
        public void TestDeadDummyThrowsExceptionIfAttacked(int health, int experience, int attackPoints)
        {
            Setup(health, experience);

            var expectedMessage = "Dummy is dead.";

            var exception = Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints), 
                "Not throws InvalidOperationException.");
            Assert.AreEqual(expectedMessage, exception.Message, "Not correct exception message");   
        }

        //•	Dead Dummy can give XP
        [TestCase(0, 10, 10)]
        [TestCase(-10, 0, 15)]
        [TestCase(-1, 100, 10)]
        public void TestDeadDummyCanGiveXP(int health, int experience, int attackPoints)
        {
            Setup(health, experience);

            var actualResult = dummy.GiveExperience();

            Assert.AreEqual(experience, actualResult, "Dead Dummy can't give XP");
        }

        //•	Alive Dummy can't give XP
        [TestCase(10, 10, 10)]
        [TestCase(100, 10, 15)]
        [TestCase(1, 10, 10)]
        public void TestAliveDummyCanNotGiveXP(int health, int experience, int attackPoints)
        {
            Setup(health, experience);

            var expectedMessage = "Target is not dead.";

            var exception = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(),
                "Not throws InvalidOperationException.");
            Assert.AreEqual(expectedMessage, exception.Message, "Not correct exception message");
        }
    }
}