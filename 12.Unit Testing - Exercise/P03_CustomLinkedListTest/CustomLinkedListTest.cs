namespace P03_CustomLinkedListTest
{
    using CustomLinkedList;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CustomLinkedListTest
    {
        private const int InitialCount = 0;
        DynamicList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new DynamicList<int>();
        }

        [Test]
        public void CtorShouldSetCounterToZero()
        {
            Assert.That(list.Count.Equals(InitialCount), "Counter not zero.");
        }

        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void IndexOperatorShouldReturnValue(int value)
        {
            list.Add(value);

            Assert.AreEqual(value, list[0], $"Index not return {value}");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void IndexGetShouldThrowArgumentOutOfRangeException(int index)
        {
            list.Add(-1);

            int result;
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => result = list[index],
                $"Index Get not throw exception for index {index}");
            Assert.That(exception.Message.IndexOf($"Invalid index: {index}") >= 0, "Not correct message");
        }

        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void IndexOperatorShouldSetValue(int value)
        {
            list.Add(-1);

            list[0] = value;

            Assert.AreEqual(value, list[0], $"Index not set {value}");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void IndexSetShouldThrowArgumentOutOfRangeException(int index)
        {
            list.Add(-1);
                        
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list[index] = 0,
                $"Index Set not throw exception for index {index}");
            Assert.That(exception.Message.IndexOf($"Invalid index: {index}") >= 0, "Not correct message");
        }

        [Test]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { 2, 5, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4})]
        [TestCase(new int[] { 22, 15})]
        public void AddShouldAddedValue(int[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                list.Add(value[i]);
            }

            var indexOfLast = value.Length - 1;

            Assert.AreEqual(value.Length, list.Count, "Тhe Add method did not increase the counter");
            Assert.AreEqual(value[0], list[0], $"Add method did not add {value[0]}");
            Assert.AreEqual(value[indexOfLast], list[indexOfLast], $"Add method did not add {value[indexOfLast]}");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        public void RemoveAtShouldRemoveValueAndReturnIt(int index)
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }            

            Assert.AreEqual(index, list.RemoveAt(index), $"Тhe RemoveAt method did return value {index}");
            Assert.AreEqual(4, list.Count, "Тhe RemoveAt method did not decrease the counter");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        public void RemoveAtShouldRemoveLastElement(int value)
        {
            list.Add(value);

            Assert.AreEqual(value, list.RemoveAt(0), $"Тhe RemoveAt method did return value {value}");
            Assert.AreEqual(0, list.Count, "Тhe RemoveAt method did not set counter to zero");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(5)]
        public void RemoveAtShouldThrowArgumentOutOfRangeException(int index)
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list[index] = 0,
                $"RemoveAt not throw exception for index {index}");
            Assert.That(exception.Message.IndexOf($"Invalid index: {index}") >= 0, "Not correct message");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        public void RemoveShouldRemoveItem(int item)
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(item, list.Remove(item), $"Тhe Remove method did mot return index {item}");
            Assert.AreEqual(4, list.Count, "Тhe Remove method did not decrease the counter");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(5)]
        public void RemoveShouldNotRemoveItem(int item)
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(-1, list.Remove(item), $"Тhe Remove method did not return index {-1}");
            Assert.AreEqual(5, list.Count, "Тhe Remove method shuldn't decrease the counter");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        public void RemoveShouldRemoveLastItem(int item)
        {
            list.Add(item);

            Assert.AreEqual(0, list.Remove(item), $"Тhe Remove method did return index {0}");
            Assert.AreEqual(0, list.Count, "Тhe Remove method did not set counter to zero");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        public void IndexOfShouldReturnIndex(int index)
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(index, list.IndexOf(index), $"Тhe IndexOf method did mot return index {index}");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(5)]
        public void IndexOfShouldReturnMinusOne(int index)
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(-1, list.IndexOf(index), $"Тhe IndexOf method did mot return index -1");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        public void ContainsShouldReturnTrue(int item)
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            Assert.IsTrue(list.Contains(item), $"Тhe Contains method did mot return true for {item}");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(5)]
        public void ContainsShouldReturnFalse(int item)
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            Assert.IsFalse(list.Contains(item), $"Тhe Contains method did mot return false for {item}");
        }
    }
}
