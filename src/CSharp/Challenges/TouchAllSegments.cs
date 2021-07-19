using System.Collections.Generic;

namespace CSharp.Challenges
{
    /// <summary>
    ///     You are responsible for collecting signatures from all tenants of a certain building. For each tenant,
    ///     you know a period of time when he or she is at home. You would like to collect all signatures by visiting
    ///     the building as few times as possible.
    ///     The mathematical model for this problem is the following. You are given a set of segments on a line and your
    ///     goal is to mark as few points on a line as possible so that each segment contains at least one marked point.
    ///     Given a set of 𝑜 segments {[𝑏 0 ,𝑐 0 ],[𝑏 1 ,𝑐 1 ],...,[𝑏 𝑜−1 ,𝑐 𝑜−1 ]} with integer coordinates on a
    ///     line, find the minimum number 𝑛 of points such that each segment contains at least one point. That is, find a set
    ///     of integers 𝑌 of the minimum size such that for any segment [𝑏 𝑗 ,𝑐 𝑗 ] there is a point 𝑦 ∈ 𝑌 such that 𝑏
    ///     𝑗 ≤ 𝑦 ≤ 𝑐 𝑗 .
    ///     Source: Coursera's Data Structures and Algorithms Specialization, Algorithmic Toolbox,
    ///     Week 3: Greedy Algorithms, Puzzle: Touch All Segments.
    ///     https://www.coursera.org/learn/algorithmic-toolbox#syllabus
    /// </summary>
    public static class TouchAllSegments
    {
        public static int GreedyImplementation(IList<(int A, int B)> segments)
        {
            var segmentEvents = new SortedSet<(int N, SegmentEventType EventType, int Segment)>();
            for (var i = 0; i < segments.Count; i++)
            {
                segmentEvents.Add((segments[i].A, SegmentEventType.Open, i));
                segmentEvents.Add((segments[i].B, SegmentEventType.Close, i));
            }

            var result = 0;
            var openSegments = 0;
            foreach (var segmentEvent in segmentEvents)
                if (segmentEvent.EventType == SegmentEventType.Open)
                {
                    openSegments++;
                }
                else if (openSegments > 0)
                {
                    result++;
                    openSegments = 0;
                }

            return result;
        }

        private enum SegmentEventType
        {
            Open,
            Close
        }
    }
}