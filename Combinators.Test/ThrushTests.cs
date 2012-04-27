using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Combinators;
using System.Dynamic;
using Xunit;

namespace Combinators.Test
{
    public class ThrushTests
    {

        private int Square(int x)
        {
            return x * x;
        }

        private bool IsOdd(int x)
        {
            return x % 2 == 1;
        }

        [Fact]
        public void into_runs_func_on_object()
        {
            // Here's the ruby that we are trying to replicate (p. 16)
            // Considered confusing: lambda { |x| x * x }.call((1..100).select(&:odd?).inject(&:+))
            // Considered helpful:   (1..100).select(&:odd?).inject(&:+).into { |x| x * x }

            // In C#, the code executed looks about the same to me. I guess it is a matter of emphasis.
            // Do I want to emphaize the square, or the range?
            int confusing = Square(Enumerable.Range(1, 10).Where(y => IsOdd(y)).Sum(y => y));
            int helpful   = Enumerable.Range(1, 10).Where(y => IsOdd(y)).Sum(y => y).Into(Square);

            Assert.Equal(625, helpful);
        }

    }
}
