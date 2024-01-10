using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class StringExtension
    {
        public static bool IsAPalindrome(this string s)
        {
            if (s == null) return false;
            if (s.Length == 0) return false;

            string reverse = new string(s.Reverse().ToArray());

            if (reverse == s) return true;
            else return false;

        }

    }
}
