using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Combinators;
using System.Diagnostics;
using System.Dynamic;

namespace Combinators.Test
{
    [TestClass]
    public class KestrelTests
    {
        [TestMethod]
        public void tap_with_action_test_gives_back_initial_object()
        {
            var x = new Dictionary<string, object>();
            x["Foo"] = 1;
            x["Bar"] = 2;
            var result = x.Tap((item) => { 
                Debug.WriteLine("Foo: {0}, Bar: {1}", item["Foo"], item["Bar"]);
            });

            Assert.AreSame(x, result);
            Assert.AreEqual(1, result["Foo"]);
            Assert.AreEqual(2, result["Bar"]);
        }

        [TestMethod]
        public void tap_with_func_test_gives_back_modified_object_same_reference()
        {
            var x = new Dictionary<string, object>();
            x["Foo"] = 1;
            x["Bar"] = 2;
            var result = x.Tap((item) => { 
                Debug.WriteLine("Foo: {0}, Bar: {1}", item["Foo"], item["Bar"]);
                item["Foo"] = 12;
                item["Bar"] = 13;
                Debug.WriteLine("Foo: {0}, Bar: {1}", item["Foo"], item["Bar"]);
                return item;
            });

            Assert.AreSame(x, result);
            Assert.AreEqual(12, result["Foo"]);
            Assert.AreEqual(13, result["Bar"]);
            Assert.AreEqual(12, x["Foo"]);
            Assert.AreEqual(13, x["Bar"]);

        }

        [TestMethod]
        public void tap_with_func_gives_back_modified_primitive_not_same_reference()
        {

            var x = 5;
            var result = x.Tap((item) => {
                Debug.WriteLine(item);
                item = 7;
                Debug.WriteLine(item);
                return item;
            });

            Assert.AreNotSame(x, result);
            Assert.AreEqual(5, x);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void noop_with_action_no_arguments_does_not_call_action()
        {
            int bob = 0;
            int x = 4;
            var result = x.Noop(() =>
            {
                bob = 10;
            });

            Assert.AreEqual(0, bob);
        }

        [TestMethod]
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

            Assert.AreEqual(0, bob);
            Assert.AreEqual(4, result);
        }
    }
}
