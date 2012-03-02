using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Combinators
{
    public static class Kestrel
    {
        /// <summary>
        /// Kxy = x, such that given a value and an action return the value after running the action.
        /// </summary>
        /// <typeparam name="TObject">The type of the object being tapped.</typeparam>
        /// <param name="obj">The object to Tap.</param>
        /// <param name="action">The action to run on the object.</param>
        /// <returns>The object Tap was called on.</returns>
        public static TObject Tap<TObject>(this TObject obj, Action<TObject> action)
        {
            action(obj);
            return obj;
        }

        /// <summary>
        /// Kxy = x, such that given a value and a function that returns a modified x, return x after running the function.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="obj">The object to Tap.</param>
        /// <param name="func"></param>
        /// <returns>The modified object that was tapped. For objects on the heap, this means the original object is modified.</returns>
        public static TObject Tap<TObject>(this TObject obj, Func<TObject, TObject> func) 
        {
            TObject newObject = obj;
            newObject = func(newObject);
            return newObject;
        }

        /// <summary>
        /// Kxy = x, such that given an object and an action, the action is ignored
        /// </summary>
        public static TObject Noop<TObject>(this TObject obj, Action action)
        {
            return obj;
        }
        /// <summary>
        /// Kxy = x, such that given an object and an action, the action is ignored
        /// </summary>
        public static TObject Noop<TObject>(this TObject obj, Action<TObject> action)
        {
            return obj;
        }
    }
}
