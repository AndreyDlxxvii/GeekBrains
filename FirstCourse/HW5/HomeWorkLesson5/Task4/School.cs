using System;
using System.IO;

namespace Task4
{
    public static class School
    {
        struct Student
        {
            public double Sum;
            public string Name;
            
        }

        public static void SchoolDict(string path)
        {
            StreamReader str = new StreamReader(path);
            int countStudent = int.Parse(str.ReadLine());
            Student[] std = new Student[countStudent];
            char[] p = {'\n', '\r'};
            var studList = str.ReadToEnd().Split(p, StringSplitOptions.RemoveEmptyEntries); //разделям на строки содержащие ФИО и оценки
            for (int j = 0; j < countStudent; j++) // Создаем студентов в структуре c ФИО и средней оценкой
            {
                var t = studList[j].Split(' ');
                std[j].Name = t[0] + " " + t[1];
                var w = (double.Parse(t[2]) + double.Parse(t[3]) + double.Parse(t[4])) / 3;
                std[j].Sum = Math.Round(w, 4);
            }

            for (int i = 0; i < countStudent; i++) //сортировка по среднему баллу массива студентов
            {
                for (int j = 0; j < countStudent-1; j++)
                {
                    if (std[j].Sum>std[j+1].Sum)
                    {
                        var tmp=std[j+1]; 
                        std[j+1]=std[j]; 
                        std[j]=tmp;
                    }
                }
            }
            

            
            for (int i = 0; i < countStudent-1; i++)//Вывод студентов
            {
                if (i<2)
                {
                    Console.WriteLine($"Студент {std[i].Name} средний бал {std[i].Sum}");
                }

                else if(std[i].Sum==std[i+1].Sum)
                {
                    Console.WriteLine($"Студент {std[i].Name} средний бал {std[i].Sum}");
                }
                else
                {
                    Console.WriteLine($"Студент {std[i].Name} средний бал {std[i].Sum}");
                    i = countStudent;
                }

            }


        }
    }
}