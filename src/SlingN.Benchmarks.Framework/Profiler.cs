using System;
using System.Diagnostics;

namespace SlingN.Benchmarks.Framework
{
    /// <summary>
    /// From: Benchmarking Small Code Samples
    /// http://stackoverflow.com/questions/1047218/benchmarking-small-code-samples-in-c-can-this-implementation-be-improved
    /// </summary>
    public class Profiler
    {
        /// <summary>
        /// Profiles the Action executed for the specified iterations (+1 for pre JIT compiling).
        /// </summary>
        /// <param name="iterations">The number of iterations to execute the Action.</param>
        /// <param name="func">The action to execute.</param>
        /// <returns></returns>
        public static long Profile(int iterations, Action func)
        {
            // clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // warm up 
            func();

            var watch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                func();
            }
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
     
    }
}