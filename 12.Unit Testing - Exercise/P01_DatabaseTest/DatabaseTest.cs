namespace P01_DatabaseTest
{
    using IntDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class DatabaseTest
    {
        private const int ArrayCapacity = 16;
        private const int InitialArrayIndex = -1;
        private Database db;

        [Test]
        public void EmptyConstructorShouldInitData()
        {
            db = new Database();

            var dataField = (int[])GetField("data");

            var indexField = (int)GetField("index");

            Assert.IsNotNull(dataField, "Internal array is null");
            Assert.That(ArrayCapacity == dataField.Length, $"Internal array not have capacity {ArrayCapacity}");
            Assert.That(indexField == InitialArrayIndex, "Index field not initial correct");
        }

        [Test]
        [TestCase(new int[] {})]
        [TestCase(new int[] {0})]
        [TestCase(new int[] {1, 2, 3, 4})]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void NonEmptyConstructorShouldInitData(int[] value)
        {
            db = new Database(value);

            var dataField = (int[])GetField("data");

            var indexField = (int)GetField("index");

            Assert.IsNotNull(dataField, "Internal array is null");
            Assert.That(ArrayCapacity == dataField.Length, $"Internal array not have capacity {ArrayCapacity}");
            Assert.That(indexField == value.Length - 1, "Index field not initial correct");
            Assert.That(dataField.Take(indexField + 1).SequenceEqual(value), "Array not filled properly");
        }

        [Test]
        public void CtorShouldThrowInvalidOperationExceptionForLargerArray()
        {
            var value = new int[ArrayCapacity + 1];

            var exception = Assert.Throws<InvalidOperationException>(() => new Database(value), "Not throw exception");
            Assert.AreEqual("Not enough capacity!", exception.Message, "Not correct message");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(15)]
        public void AddShouldIncraseIndexCorrecrly(int value)
        {
            var arr = new int[value];
            db = new Database(arr);

            db.Add(-1);

            var indexField = (int)GetField("index");

            Assert.That(indexField == value, "Index not correct after add");
        }

        [Test]
        public void AddWhenDatabaseIsFullShouldThrowInvalidOperationException()
        {
            var value = new int[ArrayCapacity];

            db = new Database(value);

            var exception = Assert.Throws<InvalidOperationException>(() => db.Add(0), "Not throw exception");
            Assert.AreEqual("Not enough capacity!", exception.Message, "Not correct message");
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(16)]
        public void RemoveSouldDecraseIndex(int value)
        {
            var arr = new int[value];
    
            db = new Database(arr);
            db.Remove();

            var indexField = (int)GetField("index");

            Assert.That(indexField == value - 2, "Index not correct after add");
        }

        [Test]
        public void RemoveWhenEmptyDatabaseShouldThrowInvalidOperationException()
        {
            db = new Database();

            var exception = Assert.Throws<InvalidOperationException>(() => db.Remove(), "Not throw exception");
            Assert.AreEqual("Database is empty!", exception.Message, "Not correct message");
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchReturnCorrectResult(int[] value)
        {
            db = new Database(value);

            var expectedResult = value.ToArray();
            var actualResult = db.Fetch();

            Assert.AreEqual(expectedResult, actualResult, "Not correct result");
        }

        private object GetField(string fieldName)
            => typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(f => f.Name == fieldName)
            .GetValue(db);

        //var field = (int[])typeof(Database)
        //    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
        //    .First(f => f.Name == "data")
        //    .GetValue(db);

        //var fields = typeof(Database)
        //        .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        //var dataField = (int[])fields
        //    .First(f => f.Name == "data")
        //    .GetValue(db);

        //var indexField = (int)fields
        //   .First(f => f.Name == "index")
        //   .GetValue(db);


        // not work
        //var fieldData = Assembly.GetCallingAssembly()
        //    .GetTypes()
        //    .First(f => f.Name == "Database")
        //    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
        //    .FirstOrDefault(f => f.Name == "data")
        //    .GetValue(db);
    }
}
