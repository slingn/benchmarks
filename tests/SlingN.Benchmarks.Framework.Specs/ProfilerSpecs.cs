using System;
using Machine.Fakes;
using Machine.Specifications;

namespace SlingN.Benchmarks.Framework.Specs
{
    public class When_profiling : WithFakes
    {
        static Action method;
        static int iterations = 2;

        Establish context = () =>
            {
                method = An<Action>();
            };

        Because of = () => result = Profiler.Profile(iterations, method);

        It should_execute_the_provided_action_one_more_time_than_specified_by_the_number_of_iterations_so_that_it_can_pre_jit_the_method = () => 
            method.WasToldTo(m => m.Invoke()).Times(3);

        static long result; 
    }
}