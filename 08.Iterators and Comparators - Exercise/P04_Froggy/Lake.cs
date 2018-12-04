namespace P04_Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    class Lake<T> : IEnumerable<T>
    {
        private readonly T[] stones;

        public Lake(T[] stones)
        {
            this.stones = stones;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i += 2)
            {
                yield return stones[i];
            }

            var length = stones.Length % 2 == 0 ? stones.Length - 1 : stones.Length - 2;

            for (int i = length; i >= 0; i -= 2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
