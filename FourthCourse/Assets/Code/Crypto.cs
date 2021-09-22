using System;

namespace Code
{
    public static class Crypto
    {
        public static string MyCrypto(string text)
        {
            string res = null;
            foreach (var ell in text)
            {
                res += (char)~ell;
            }
            return res;
        }
    }
}