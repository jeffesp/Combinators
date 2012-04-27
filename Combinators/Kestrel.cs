using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Combinators
{
    public static class Kestrel
    {
        /// <summary>
        /// Kxy = x, such that given a value and an action return the value after running the action. (Kestrel or K Combinator).
        /// </summary>
        /// <typeparam name="TObject">The type of the object being tapped.</typeparam>
        /// <param name="obj">The object to Tap.</param>
        /// <param name="action">The action to run on the object.</param>
        /// <returns>The object Tap was called on.</returns>
        /// <seealso cref="Returning"/>
        public static TObject Tap<TObject>(this TObject obj, Action<TObject> action) 
        {
            action(obj);
            return obj;
        }

        /// <summary>
        /// Kxy = x, such that given a value and a function that returns a modified x, return x after running the function. (Kestrel or K Combinator).
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
        /// Alias of the <see cref="Tap"/> K Combinator.
        /// </summary>
        /// <typeparam name="TObject">The type of the object being returned.</typeparam>
        /// <param name="obj">The object to return.</param>
        /// <param name="action">The action to run on the object.</param>
        /// <returns>The object <c>Returning</c> was called on.</returns>
        /// <seealso cref="Tap"/>
        public static TObject Returning<TObject>(this TObject obj, Action<TObject> action)
        {
            return obj.Tap(action);
        }

        public static TObject Returning<TObject>(this TObject obj, Func<TObject, TObject> func)
        {
            return obj.Tap(func);
        }

        /// <summary>
        /// Kxy = x, such that given an object and an action, the action is ignored. (Kestrel or K Combinator).
        /// </summary>
        public static TObject Noop<TObject>(this TObject obj, Action action)
        {
            return obj;
        }
        /// <summary>
        /// Kxy = x, such that given an object and an action, the action is ignored. (Kestrel or K Combinator).
        /// </summary>
        public static TObject Noop<TObject>(this TObject obj, Action<TObject> action)
        {
            return obj;
        }
    }
}
