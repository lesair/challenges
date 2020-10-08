namespace CSharp.Challenges
{
    /// <summary>
    ///     Write a function that takes a string and reverses the letters in place.
    ///     Source: Interview Cake.
    ///     https://www.interviewcake.com/question/c/reverse-string-in-place
    /// </summary>
    public static class ReverseStringCharsInPlace
    {
        /// <summary>
        ///     Author: the philosopher developer.
        ///     http://philosopherdeveloper.com/posts/are-strings-really-immutable-in-net.html
        ///     Unsafe. Pointers. Iterative.
        /// </summary>
        public static unsafe void EvilImplementation(string s)
        {
            var i = -1;
            var j = s.Length;
            fixed (char* fs = s)
            {
                while (++i < --j)
                {
                    fs[i] = (char) (fs[i] ^ fs[j]);
                    fs[j] = (char) (fs[j] ^ fs[i]);
                    fs[i] = (char) (fs[i] ^ fs[j]);
                }
            }
        }
    }
}