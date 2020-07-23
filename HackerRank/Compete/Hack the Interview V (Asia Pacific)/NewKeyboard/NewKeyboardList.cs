using System.Collections.Generic;

namespace HacerRank.Compete.NewKeyboard
{
    class NewKeyboardList
    {
        //Slow 6.1sec
        public static string receivedText(string S)
        {
            var result = new List<char>(S.Length);
            var index = 0;
            var numlock = true;
            //foreach 8.8 sec!
            for (int i = 0; i < S.Length; i++)
            {
                var ch = S[i];
                switch (ch)
                {
                    case '<':
                        index = 0;
                        break;
                    case '>':
                        index = result.Count;
                        break;
                    case '*':
                        if (index > 0)
                        {
                            index--;
                            result.RemoveAt(index);
                        }
                        break;
                    case '#':
                        numlock = !numlock;
                        break;
                    default:
                        if (!char.IsNumber(ch) || numlock && char.IsNumber(ch))
                        {
                            result.Insert(index, ch);
                            index++;
                        }
                        break;
                }
            }
            return new string(result.ToArray());
        }
    }
}
