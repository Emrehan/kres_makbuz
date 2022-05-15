using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.Helper
{
    public static class StringExtensions
    {
        public static bool EqualsAny(this string text, params string[] texts)
        {
            foreach (var s in texts)
                if (text.Equals(s))
                    return true;

            return false;
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
