using System;
using System.Collections.Generic;
using System.Diagnostics;
using Machine.Specifications;

namespace SlingN.Benchmarks.Framework.ConsumerExample.Specs
{
    public class When_benchmarking_my_method
    {
        static Action target;
        static long result;

        Establish context = () =>
            {
                target = () =>
                    {
                        var items = new List<string>();
                        for (var i = 0; i < 50; i++)
                        {
                            items.Add(i.ToString());
                        }
                    };
            };

        Because of = () =>
            {
                result = Profiler.Profile(100, target);
                Debug.WriteLine("Executed Target in {0} ms", result);
            };

        It should_execute_in_under_100ms = () => result.ShouldBeLessThan(100);

    }
}