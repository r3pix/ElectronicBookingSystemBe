using BenchmarkDotNet.Running;
using ElectronicBookingSystem.Benchmarks;
using System;

namespace Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<EmptyBenchmarks>();
            //BenchmarkRunner.Run<BasicDataBenchmarks>();
            //BenchmarkRunner.Run<HeavyDataBenchmarks>();
            BenchmarkRunner.Run<MultipleRequestBenchmark>();
        }
    }
}
