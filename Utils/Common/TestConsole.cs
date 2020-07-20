using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit.Abstractions;

namespace Common
{
    public class TestConsole : TextWriter
    {
        readonly ITestOutputHelper _output;

        public TestConsole(ITestOutputHelper output)
        {
            _output = output;
            Result = new List<string>();
        }
        public List<string> Result { get; }
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
        public override void WriteLine(string message)
        {
            _output.WriteLine(message);
            Result.Add(message);
        }
        public override void WriteLine(string format, params object[] args)
        {
            _output.WriteLine(format, args);
        }
    }
}
