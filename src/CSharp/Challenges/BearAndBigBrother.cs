namespace CSharp.Challenges
{
    /// <summary>
    ///     Bear and Big Brother
    ///     Source: Codeforces.
    ///     https://codeforces.com/problemset/problem/791/A
    /// </summary>
    public static class BearAndBigBrother
    {
        public static int GetsValue(int limak, int bob)
        {
            var years = 0;
            while (limak <= bob)
            {
                limak *= 3;
                bob *= 2;
                years++;
            }

            return years;
        }
    }
}
