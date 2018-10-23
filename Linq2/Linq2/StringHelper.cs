using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Linq2
{
    static class StringHelper
    {
        public static bool CheckEmail(this string str,string pattern)
        {
            Regex reg = new Regex(pattern);
            if (reg.IsMatch(pattern) == false)
                return false;

            Match match = reg.Match(str);

            if (match.Value == "")
                return false;

            return true;
        }
    }
}
