namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test] // Test 1 amd 3
        public void TestInitial()
        {
            var assembler = new VehicleAssembler();
            var vehiacle = new Revenger("model", 300.5, 123.3M, 150, 100, 50, assembler);

            Assert.That(vehiacle, Is.Not.Null);
        }

        [Test] // Test 2
        public void TestData()
        {
            var assembler = new VehicleAssembler();
            var vehiacle = new Revenger("model", 300.5, 123.3M, 150, 100, 50, assembler);
            var arsenalPart = new ArsenalPart("arsenal", 50, 12.5M, 10);
            var shellPart = new ShellPart("shell", 15, 10.5M, 12);
            var endurancePart = new EndurancePart("endurance", 12, 5.2M, 6);
            vehiacle.AddArsenalPart(arsenalPart);
            vehiacle.AddShellPart(shellPart);
            vehiacle.AddEndurancePart(endurancePart);

            Assert.AreEqual("model", vehiacle.Model);
            Assert.AreEqual(300.5, vehiacle.Weight);
            Assert.AreEqual(123.3M, vehiacle.Price);
            Assert.AreEqual(150, vehiacle.Attack);
            Assert.AreEqual(100, vehiacle.Defense);
            Assert.AreEqual(50, vehiacle.HitPoints);
            Assert.AreEqual(377.5, vehiacle.TotalWeight);
            Assert.AreEqual(151.5M, vehiacle.TotalPrice);
            Assert.AreEqual(160, vehiacle.TotalAttack);
            Assert.AreEqual(112, vehiacle.TotalDefense);
            Assert.AreEqual(56, vehiacle.TotalHitPoints);
        }

        [Test] // Test 4
        public void TestToString()
        {
            var assembler = new VehicleAssembler();
            var vehiacle = new Revenger("model", 300.5, 123.3M, 150, 100, 50, assembler);

            string expectedResult = "Revenger - model\r\nTotal Weight: 300.500\r\nTotal Price: 123.300\r\nAttack: 150\r\nDefense: 100\r\nHitPoints: 50\r\nParts: None";
            string actualResult = vehiacle.ToString();

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void TestExceptionModel()
        {
            var assembler = new VehicleAssembler();

            Assert.Throws<ArgumentException>(() => new Revenger(null, 300.5, 123.3M, 150, 100, 50, assembler));
        }

        [Test]
        public void TestExceptionWeight()
        {
            var assembler = new VehicleAssembler();

            Assert.Throws<ArgumentException>(() => new Revenger("model", -300.5, 123.3M, 150, 100, 50, assembler));
        }

        [Test]
        public void TestExceptionPrice()
        {
            var assembler = new VehicleAssembler();

            Assert.Throws<ArgumentException>(() => new Revenger("model", 300.5, -123.3M, 150, 100, 50, assembler));
        }

        [Test]
        public void TestExceptionAttack()
        {
            var assembler = new VehicleAssembler();

            Assert.Throws<ArgumentException>(() => new Revenger("model", 300.5, 123.3M, -150, 100, 50, assembler));
        }

        [Test]
        public void TestExceptionDefense()
        {
            var assembler = new VehicleAssembler();

            Assert.Throws<ArgumentException>(() => new Revenger("model", 300.5, 123.3M, 150, -100, 50, assembler));
        }

        [Test]
        public void TestExceptionHitPoints()
        {
            var assembler = new VehicleAssembler();
            
            Assert.Throws<ArgumentException>(() => new Revenger("model", 300.5, 123.3M, 150, 100, -50, assembler));
        }
    }
}