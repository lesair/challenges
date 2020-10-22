namespace CSharp.Challenges
{
    /// <summary>
    ///     Given a string S, return the "reversed" string where all characters that are not a letter stay in the same place,
    ///     and all letters reverse their positions.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/reverse-only-letters/
    ///     Source: Kevin Naughton Jr.
    ///     https://youtu.be/qVADz0khbH0
    /// </summary>
    public static class ReverseOnlyLettersInString
    {
        /// <summary>
        ///     Iterative. Manual.
        ///     Multiple pointers manipulation.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static string IterativeImplementation(string s)
        {
            var chars = s.ToCharArray();
            var l = 0;
            var r = chars.Length - 1;
            while (l < r)
            {
                while (l < r && !char.IsLetter(chars[l]))
                    l++;
                while (r > l && !char.IsLetter(chars[r]))
                    r--;
                if (l == r) continue;
                chars[l] = (char) (chars[l] ^ chars[r]);
                chars[r] = (char) (chars[r] ^ chars[l]);
                chars[l] = (char) (chars[l++] ^ chars[r--]);
            }

            return new string(chars);
        }
    }
}