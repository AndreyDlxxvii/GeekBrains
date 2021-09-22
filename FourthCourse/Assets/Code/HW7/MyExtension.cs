using UnityEngine;

namespace Code.HW7
{
    public static class MyExtension
    {
        public static string SymbolCounter(this string self)
        {
            return self.Length.ToString();
        }
    }
}