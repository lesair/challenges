using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class DataStreamMedianSearch
    {
        public DataStreamMedianSearch()
        {
            _implementations = new MedianFinder[]
                {new BuiltInBinarySearchImplementation(), new ManualBinarySearchImplementation()};
        }

        private readonly MedianFinder[] _implementations;

        [Fact]
        public void ReturnsTheExpectedMedians()
        {
            foreach (var implementation in _implementations)
            {
                implementation.AddNum(1);
                implementation.AddNum(2);
                implementation.FindMedian().ShouldBe(1.5);
                implementation.AddNum(3);
                implementation.FindMedian().ShouldBe(2);
            }
        }

        [Fact]
        public void ReturnsTheExpectedMediansForDuplicatedValues()
        {
            foreach (var implementation in _implementations)
            {
                implementation.AddNum(2);
                implementation.AddNum(2);
                implementation.AddNum(2);
                implementation.AddNum(3);
                implementation.AddNum(3);
                implementation.FindMedian().ShouldBe(2);
                implementation.AddNum(3);
                implementation.AddNum(3);
                implementation.FindMedian().ShouldBe(3);
            }
        }


        [Fact]
        public void ReturnsTheExpectedMediansWhenUnsortedValuesAreAdded()
        {
            foreach (var implementation in _implementations)
            {
                implementation.AddNum(5);
                implementation.AddNum(1);
                implementation.AddNum(9);
                implementation.AddNum(7);
                implementation.AddNum(3);
                implementation.AddNum(3);
                implementation.FindMedian().ShouldBe(4);
            }
        }
    }
}