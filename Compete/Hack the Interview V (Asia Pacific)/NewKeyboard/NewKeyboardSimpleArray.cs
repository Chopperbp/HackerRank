using System;
using System.Linq;

namespace Challenges.NewKeyboard
{
    class NewKeyboardSimpleArray
    {
        public static string receivedText(string S)
        {
            var result = new char[S.Length];
            var numlock = true;
            var current = -1;
            var head = 0;
            var last = current;
            for (int i = 0; i < S.Length; i++)
            {
                var ch = S[i];
                switch (ch)
                {
                    case '<':
                        current = head - 1;
                        break;
                    case '>':
                        current = last;
                        break;
                    case '*':
                        if (current >= 0)
                        {
                            if (current != last)
                            {
                                Array.Copy(result, current + 1, result, current, last - current);
                            }
                            current--;
                            last--;
                        }
                        break;
                    case '#':
                        numlock = !numlock;
                        break;
                    default:
                        if (!char.IsNumber(ch) || numlock && char.IsNumber(ch))
                        {
                            if (current != last)
                            {
                                Array.Copy(result, current + 1, result, current + 2, last - current);
                            }
                            result[current + 1] = ch;
                            current++;
                            last++;
                        }
                        break;
                }
            }
            Array.Resize(ref result, last + 1);
            return new string(result.ToArray());
        }
    }
}
