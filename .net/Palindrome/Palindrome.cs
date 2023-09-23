using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    public static class Palindrome
    {
        
        public static bool IsAPalindrome(this String s)
        {
            if( s == null ) return false;
            if( s.Length == 0 ) return false;
            String reverseString = new String( s.Reverse().ToArray() );
            if(reverseString==s) return true;
            return false;
        }
    }
}
