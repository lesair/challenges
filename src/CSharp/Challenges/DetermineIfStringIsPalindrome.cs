using System.Linq;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Determines if a given string is a palindrome.
    ///     Advanced Unicode validations like the Turkish test o code points (described in Jon Skeet's
    ///     https://codeblog.jonskeet.uk/2009/11/02/omg-ponies-aka-humanity-epic-fail/are) are out of scope of this challenge.
    ///     Source: Code Golf Stack Exchange
    ///     https://codegolf.stackexchange.com/questions/11155/shortest-code-to-determine-if-a-string-is-a-palindrome
    ///     Source: Working at Microsoft YouTube channel.
    ///     https://youtu.be/8Myx-vy0csM?t=283
    /// </summary>
    public static class DetermineIfStringIsPalindrome
    {
        /// <summary>
        ///     Iterative, LINQ.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static bool LinqImplementation(string s)
        {
            var validChars = s.ToLower().Where(char.IsLetterOrDigit).ToArray();
            return validChars.SequenceEqual(validChars.Reverse());
        }

        /// <summary>
        ///     Iterative, manual.
        ///     Multiple pointers manipulation.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static bool ManualIterationImplementation(string s)
        {
            var start = 0;
            var end = s.Length - 1;
            while (start < end)
            {
                if (char.IsLetterOrDigit(s[start]) && char.IsLetterOrDigit(s[end]))
                {
                    if (char.ToLower(s[start]) != char.ToLower(s[end]))
                        return false;
                    start++;
                    end--;
                }
                else
                {
                    if (!char.IsLetterOrDigit(s[start]))
                        start++;
                    if (!char.IsLetterOrDigit(s[end]))
                        end--;
                }
            }

            return true;
        }
    }
}