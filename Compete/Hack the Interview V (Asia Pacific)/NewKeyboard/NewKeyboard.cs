using System.Collections.Generic;
using System.Linq;

namespace Challenges.NewKeyboard
{
    class NewKeyboard
    {
        public static string receivedText(string S)
        {
            var result = new LinkedList<char>();
            var numlock = true;
            var current = result.First;
            for (int i = 0; i < S.Length; i++)
            {
                var ch = S[i];
                switch (ch)
                {
                    case '<':
                        current = null;
                        break;
                    case '>':
                        current = result.Last;
                        break;
                    case '*':
                        if (current != null)
                        {
                            var removed = current;
                            current = current.Previous;
                            result.Remove(removed);
                        }
                        break;
                    case '#':
                        numlock = !numlock;
                        break;
                    default:
                        if (!char.IsNumber(ch) || numlock && char.IsNumber(ch))
                        {
                            if (current == null)
                            {
                                current = result.AddFirst(ch);
                            }
                            else
                            {
                                current = result.AddAfter(current, ch);
                            }
                        }
                        break;
                }
            }
            return new string(result.ToArray());
        }
    }
}
