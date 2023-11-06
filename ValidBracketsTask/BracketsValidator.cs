using System;

namespace ValidBracketsTask
{
    /// <summary>
    /// Provides methods to validate of the correct placement of brackets in the string.
    /// </summary>
    public class BracketsValidator
    {
        private static readonly Dictionary<char, char> BracketPairs = new ()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
        };

        /// <summary>
        /// Validates of the correct placement of brackets in the string.
        /// </summary>
        /// <param name="input">String to validate.</param>
        /// <returns>true if the pairs of brackets are placed correctly, otherwise - false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if string is null.</exception>
        public bool IsValid(string? input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Can't be null.");
            }

            var stack = new Stack<char>();

            foreach (var simbol in input)
            {
                if (BracketPairs.ContainsKey(simbol))
                {
                    stack.Push(simbol);
                }
                else if (BracketPairs.ContainsValue(simbol) && (stack.Count == 0 || BracketPairs[stack.Pop()] != simbol))
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
