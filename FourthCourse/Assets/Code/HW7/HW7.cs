using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.HW7
{
    public class HW7
    {
        private string i = "Сколько символов в строке";

        public void Task2()
        {
            Debug.Log($@"В строке ({i}), {i.SymbolCounter()} символов");
        }
        
        public void Task3()
        {
            List<int> list = new List<int> {1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,7,8,9};
            list.Sort();
            list.OrderBy(p => 1);
            foreach (var ell in list.Distinct())
            {
            Debug.Log(ell + " " + list.Where(x => x == ell).Count() + " раз");
            }
            var t = list.FindAll(i1 => i1 == 1 );
            Debug.Log(list); 
        }

        public void Task4()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four", 4},
                {"two", 2},
                {"one", 1},
                {"three", 3},
            };
            //исходный вид
            var q = dict.OrderBy(delegate(KeyValuePair<string,int> pair) { return pair.Value; });
            foreach (var pair in q)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
            //Свернутое с обращение при помощи лябды
            var d = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
            //Развернуть обращение к OrderBy при помощи делегата
            Func<KeyValuePair<string, int>, int> myFunc = MyFunc;
            var w = dict.OrderBy(myFunc);
            foreach (var pair in w)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
        }

        private int MyFunc(KeyValuePair<string, int> arg)
        {
            var t = arg;
            return arg.Value;
        }
    }
}
