using System.Collections.Generic;

namespace Utility
{
    public static class IEnumerableExtension
    {
        public static T GetElementByIndex<T>(this IEnumerable<T> values, int index)
        {
            int i = 0;
            foreach (T element in values)
            {
                if(i == index)
                    return element;

                i++;
            }

            return default;
        }
    }
}