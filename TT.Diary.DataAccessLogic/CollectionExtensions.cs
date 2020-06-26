using System;
using System.Collections.Generic;

namespace TT.Diary.DataAccessLogic
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> GetRecursively<T>(this IEnumerable<T> items, Func<T, IEnumerable<T>> childSelector)
        {
            foreach (var next in items)
            {
                yield return next;
                foreach (var child in childSelector(next))
                {
                    yield return child;
                }
            }
        }
    }
}