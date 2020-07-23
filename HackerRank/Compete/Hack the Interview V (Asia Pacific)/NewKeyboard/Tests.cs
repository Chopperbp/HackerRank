using Xunit;

//https://www.hackerrank.com/contests/hack-the-interview-v-asia-pacific/challenges/strange-keyboard-1/problem
//https://www.hackerearth.com/practice/notes/abhinav92003/why-output-the-answer-modulo-109-7/
//https://codeaccepted.wordpress.com/2014/02/15/output-the-answer-modulo-109-7/
namespace HacerRank.Compete.NewKeyboard
{
    public partial class Tests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Test(string S, string expected)
        {
            string result = NewKeyboard.receivedText(S);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TestList(string S, string expected)
        {
            string result = NewKeyboardList.receivedText(S);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TestArray(string S, string expected)
        {
            string result = NewKeyboardArray.receivedText(S);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TestSimpleArray(string S, string expected)
        {
            string result = NewKeyboardSimpleArray.receivedText(S);
            Assert.Equal(expected, result);
        }
    }
}
