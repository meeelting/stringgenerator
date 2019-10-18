using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unleash_the_giraffe
{
    static class ListExtensions
    {
        static public T RandomElement<T>(this List<T> list, Random random)
        {
            if (list == null || list.Count == 0)
            {
                return default;
            }

            return list[random.Next(0, list.Count)];
        }
    }
}
