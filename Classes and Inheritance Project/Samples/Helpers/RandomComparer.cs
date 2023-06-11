namespace Samples.Helpers
{
    /// <summary>
    /// Random comparer to randomly sort list.
    /// </summary>
    internal class RandomComparer : IComparer<Student>
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Determines if x is less than, equal to, or greater than y
        /// </summary>
        /// <param name="x">First item</param>
        /// <param name="y">Second item</param>
        /// <returns>Number indicating if x should be before, after, or at the same position as y</returns>
        public int Compare(Student x, Student y)
        {
            if (x == y) return 0;

            int result = this._random.Next(-1, 1);
            return result;
        }
    }
}
