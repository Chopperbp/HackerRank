using BenchmarkDotNet.Running;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher
                .FromAssembly(typeof(Common.CommonTest).Assembly)
                .Run(new string[] { "--job","short","--runtimes", "netcoreapp31", "--filter","*" }, new AllowNonOptimized());
        }
    }
}
