using System;
using System.Collections.Generic;
using Xunit;

namespace Combinators.Test
{
    public class KestrelTests
    {
        [Fact]
        public void tap_with_action_gives_back_initial_object()
        {
            var x = new Dictionary<string, object>();
            x["Foo"] = 1;
            x["Bar"] = 2;
            var result = x.Tap((item) => { 
                int sum = (int)item["Foo"] + (int)item["Bar"];
            });

            Assert.Same(x, result);
            Assert.Equal(1, result["Foo"]);
            Assert.Equal(2, result["Bar"]);
        }

        [Fact]
        public void tap_with_func_gives_back_modified_object_same_reference()
        {
            var x = new Dictionary<string, object>();
            x["Foo"] = 1;
            x["Bar"] = 2;
            var result = x.Tap((item) => { 
                item["Foo"] = 12;
                item["Bar"] = 13;
                return item;
            });

            Assert.Same(x, result);
            Assert.Equal(12, result["Foo"]);
            Assert.Equal(13, result["Bar"]);
            Assert.Equal(12, x["Foo"]);
            Assert.Equal(13, x["Bar"]);

        }

        [Fact]
        public void tap_with_func_gives_back_modified_primitive_not_same_reference()
        {
            var x = 5;
            var result = x.Tap((item) => {
                item = 7;
                return item;
            });

            Assert.NotSame(x, result);
            Assert.Equal(5, x);
            Assert.Equal(7, result);
        }

        [Fact]
        public void noop_with_action_no_arguments_does_not_call_action()
        {
            int bob = 0;
            int x = 4;
            var result = x.Noop(() =>
            {
                bob = 10;
            });

            Assert.Equal(0, bob);
        }

        [Fact]
        public void noop_with_action_argument_does_not_call_action()
        {
            int bob = 0;
            int x = new Int32();
            x = 4;
            var result = x.Noop((item) =>
            {
                item = 10;
                bob = 10;
            });

            Assert.Equal(0, bob);
            Assert.Equal(4, result);
        }
    }
}
