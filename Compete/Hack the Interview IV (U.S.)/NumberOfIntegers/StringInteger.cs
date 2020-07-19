using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges.NumberOfIntegers
{
    class StringInteger
    {

        private readonly List<int> numbers;
        public StringInteger(string value)
        {
            numbers = value.TrimStart('0').Select(c => c - '0').Reverse().ToList();
        }
        public void Increment()
        {
            var i = 0;
            int carry = 1;
            do
            {
                numbers[i] += carry;
                carry = numbers[i] / 10;
                numbers[i] %= 10;
                i++;
                if (carry > 0 && i == numbers.Count)
                {
                    numbers.Add(1);
                    carry = 0;
                }
            } while (carry > 0 && i < numbers.Count);
        }
        public int GetNonZeroNumbers()
        {
            return numbers.Count(i => i != 0);
        }
        public override string ToString()
        {
            return string.Join("", numbers.ToArray().Reverse());
        }
    }
}
