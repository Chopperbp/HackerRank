using System;
using System.Linq;

namespace HacerRank.Compete.NewKeyboard
{
    class NewKeyboardArray
    {
        //43.4 sec slow with memory Copy and Resize
        public static string receivedText(string S)
        {
            var result = new char[0];
            var index = 0;
            var numlock = true;
            for (int i = 0; i < S.Length; i++)
            {
                var ch = S[i];
                switch (ch)
                {
                    case '<':
                        index = 0;
                        break;
                    case '>':
                        index = result.Length;
                        break;
                    case '*':
                        if (index > 0)
                        {
                            index--;
                            RemoveAt(ref result, index);
                        }
                        break;
                    case '#':
                        numlock = !numlock;
                        break;
                    default:
                        if (numlock && char.IsNumber(ch) || !char.IsNumber(ch))
                        {
                            Insert(ref result, index, ch);
                            index++;
                        }
                        break;
                }
            }
            return new string(result.ToArray());
        }

        private static void RemoveAt<T>(ref T[] arr, int index)
        {
            for (int a = index; a < arr.Length - 1; a++)
            {
                // moving elements downwards, to fill the gap at [index]
                arr[a] = arr[a + 1];
            }
            // finally, let's decrement Array's size by one
            Array.Resize(ref arr, arr.Length - 1);
        }
        private static void Insert<T>(ref T[] arr, int index, T item)
        {
            T[] result = new T[arr.Length + 1];
            Array.Copy(arr, result, index);
            Array.Copy(arr, index, result, index + 1, arr.Length - index);
            result[index] = item;
            arr = result;
        }
        private static void Add<T>(ref T[] arr, T item)
        {
            T[] result = new T[arr.Length + 1];
            arr.CopyTo(result, 0);
            result[arr.Length] = item;
            arr = result;
        }
    }
}
