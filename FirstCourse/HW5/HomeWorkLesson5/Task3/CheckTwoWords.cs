using System;

namespace Task3
{
    static class CheckTwoWords
    {
        public static void Check(string word1, string word2)
        {
            bool flag = false;
            char[] firstWord = word1.ToCharArray();
            char[] secondWord = word2.ToCharArray();
            int wordLen = firstWord.Length;
            Array.Sort(firstWord);
            Array.Sort(secondWord);
            if (firstWord.Length == secondWord.Length)
            {
                for (int i = 0; i < wordLen; i++)
                {
                    if (firstWord[i]==secondWord[i])
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        i = firstWord.Length;
                    }
                }
            }
            
            switch (flag)
            {
                case true:
                    Console.WriteLine("Слова являются перестановкой");
                    break;
                case false:
                    Console.WriteLine("Слова не являются перестановкой");
                    break;
            }
        }
    }
}