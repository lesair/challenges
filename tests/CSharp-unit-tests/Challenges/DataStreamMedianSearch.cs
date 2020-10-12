using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class DataStreamMedianSearch
    {
        [Fact]
        public void ReturnsTheExpectedMedians()
        {
            var medianFinder = new MedianFinder();
            medianFinder.AddNum(1);
            medianFinder.AddNum(2);
            medianFinder.FindMedian().ShouldBe(1.5);
            medianFinder.AddNum(3);
            medianFinder.FindMedian().ShouldBe(2);
        }

        [Fact]
        public void ReturnsTheExpectedMediansForDuplicatedValues()
        {
            var medianFinder = new MedianFinder();
            medianFinder.AddNum(2);
            medianFinder.AddNum(2);
            medianFinder.AddNum(2);
            medianFinder.AddNum(3);
            medianFinder.AddNum(3);
            medianFinder.FindMedian().ShouldBe(2);
            medianFinder.AddNum(3);
            medianFinder.AddNum(3);
            medianFinder.FindMedian().ShouldBe(3);
        }
    }
}