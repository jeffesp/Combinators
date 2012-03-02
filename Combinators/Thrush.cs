using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Combinators
{
    public static class Thrush
    {
        public static TResult Into<TObject, TResult>(this TObject obj, Func<TObject, TResult> func)
        {
            if (obj == null)
                return default(TResult);
            else
                return func(obj);
        }
    }
}
