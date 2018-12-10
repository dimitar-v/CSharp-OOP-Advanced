using NUnit.Framework;
using Moq;

namespace Tests
{
    public class HeroTests
    {
        Mock<IWeapon> fakeWeapon;
        Mock<ITarget> fakeTarget;
        Hero hero;

        [SetUp]
        public void Setup()
        {
            fakeWeapon = new Mock<IWeapon>();
            fakeTarget = new Mock<ITarget>();
            hero = new Hero("Pesho", fakeWeapon.Object);
        }

        //Test if a hero gains XP when the target dies
        [TestCase(20)]
        [TestCase(50)]
        [TestCase(0)]
        public void TestHeroGainsXpWhenTargetDies(int experience)
        {
            //fakeTarget.Setup(t => t.Health).Returns(health);
            fakeTarget.Setup(t => t.GiveExperience()).Returns(experience);
            fakeTarget.Setup(t => t.IsDead()).Returns(true);

            hero.Attack(fakeTarget.Object);

            //Assert.That(hero.Experience, Is.EqualTo(experience));
            //Assert.AreEqual(experience, hero.Experience, "Hero not gains XP when the target dies.");
            //Assert.That(hero.Experience.Equals(experience), "Hero not gains XP when the target dies.");
            //Assert.That(() => experience == hero.Experience, Is.True, "Hero not gains XP when the target dies.");
            Assert.IsTrue(experience == hero.Experience, "Hero not gains XP when the target dies.");
        }
    }
}