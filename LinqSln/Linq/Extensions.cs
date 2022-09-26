using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    internal static class Extensions
    {
        internal static string FirstCaseUpper(this string input)
        {
            if (string.IsNullOrEmpty(input)) throw new NullReferenceException();
            
            return input[0].ToString().ToUpper() + input.Substring(1);
        }
        internal static IEnumerable<T> MyFilter<T>(this IEnumerable<T> input, Func<T,bool> predicate)
        {
            foreach (var item in input)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
