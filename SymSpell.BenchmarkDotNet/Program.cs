using System.Reflection;
using BenchmarkDotNet.Running;

namespace SymSpellBenchmarkDotNet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssemblies(new Assembly[]
            {
                Assembly.GetExecutingAssembly(),
            }).Run(args);
        }
    }
}
