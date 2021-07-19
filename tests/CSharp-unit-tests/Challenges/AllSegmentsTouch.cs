using System.Collections.Generic;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class AllSegmentsTouch
    {
        [Fact]
        public void ReturnsMinimumNumberOfPointsTestCase01()
        {
            var segments = new List<(int A, int B)> {(1, 3)};
            const int expected = 1;
            var actual = TouchAllSegments.GreedyImplementation(segments);
            actual.ShouldBe(expected);
        }

        [Fact]
        public void ReturnsMinimumNumberOfPointsTestCase02()
        {
            var segments = new List<(int A, int B)> {(1, 3), (4, 6)};
            const int expected = 2;
            var actual = TouchAllSegments.GreedyImplementation(segments);
            actual.ShouldBe(expected);
        }

        [Fact]
        public void ReturnsMinimumNumberOfPointsTestCase03()
        {
            var segments = new List<(int A, int B)> {(1, 3), (4, 6), (7, 9)};
            const int expected = 3;
            var actual = TouchAllSegments.GreedyImplementation(segments);
            actual.ShouldBe(expected);
        }

        [Fact]
        public void ReturnsMinimumNumberOfPointsTestCase04()
        {
            var segments = new List<(int A, int B)> {(1, 3), (4, 6), (3, 4)};
            const int expected = 2;
            var actual = TouchAllSegments.GreedyImplementation(segments);
            actual.ShouldBe(expected);
        }

        [Fact]
        public void ReturnsMinimumNumberOfPointsTestCase05()
        {
            var segments = new List<(int A, int B)> {(1, 3), (2, 5), (3, 6)};
            const int expected = 1;
            var actual = TouchAllSegments.GreedyImplementation(segments);
            actual.ShouldBe(expected);
        }

        [Fact]
        public void ReturnsMinimumNumberOfPointsTestCase06()
        {
            var segments = new List<(int A, int B)> {(4, 7), (1, 3), (2, 5), (5, 6)};
            const int expected = 2;
            var actual = TouchAllSegments.GreedyImplementation(segments);
            actual.ShouldBe(expected);
        }

        [Fact]
        public void ReturnsMinimumNumberOfPointsTestCase07()
        {
            var segments = new List<(int A, int B)> {(5, 5), (-1, 4), (-3, -2), (2, 4), (-5, -3), (3, 5), (-1, 3)};
            const int expected = 3;
            var actual = TouchAllSegments.GreedyImplementation(segments);
            actual.ShouldBe(expected);
        }
    }
}