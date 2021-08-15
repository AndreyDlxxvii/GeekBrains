using System;
using static UnityEngine.Debug;

namespace GeekBrainsHW
{
    class ChangeTwoNumbers
    {
        private int a = 5;
        private int b = 6;

        public void Changes()
        {
            Log($"До обмена а = {a} , число b = {b}");
            b += a;
            a = b - a;
            b -= a;
            Log($"После обмена а = {a} , число b = {b}");
        }
    }
}