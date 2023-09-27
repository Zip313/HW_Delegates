using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Delegates
{
    public static class GetMaxWithDelegate
    {
        public static T GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter) where T : class
        {
            T maxItem = null;
            float maxItemf = 0;
            float temp = 0;
            foreach (var item in e)
            {
                temp = getParameter(item);
                if (temp > maxItemf) { maxItemf = temp; maxItem = item; }
            }

            return maxItem;
        }
    }
}
