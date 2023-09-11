using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ParallelWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Ввод слов которые нужно найти
                Console.Write("Введите первое слово: ");
                string readwords_one = Console.ReadLine();
                Console.Write("Введите второе слово: ");
                string readwords_two = Console.ReadLine();
                Console.Write("Введите третье слово: ");
                string readwords_three = Console.ReadLine();
                Console.Write("Введите четвертое слово: ");
                string readwords_four = Console.ReadLine();
                Console.Write("Введите пятое слово: ");
                string readwords_five = Console.ReadLine();


                //Считываем текст из файла
                string text = File.ReadAllText(@"D:\Codding\C#\3.2 Параллельные потоки 2.0\file\WaarAndPeace.txt");

                //Удаляем знаки препинания
                text = text.Replace(".", "");
                text = text.Replace(",", "");
                text = text.Replace("/", "");
                text = text.Replace("?", "");
                text = text.Replace("&", "");
                text = text.Replace("[", "");
                text = text.Replace("]", "");
                text = text.Replace("{", "");
                text = text.Replace("}", "");
                text = text.Replace("!", "");
                text = text.Replace("@", "");
                text = text.Replace("#", "");
                text = text.Replace("$", "");
                text = text.Replace("*", "");
                text = text.Replace("^", "");
                text = text.Replace("%", "");
                text = text.Replace("(", "");
                text = text.Replace(")", "");
                text = text.Replace(":", "");
                text = text.Replace(";", "");
                text = text.Replace("<", "");
                text = text.Replace("-", "");
                text = text.Replace(">", "");
                text = text.Replace("/n", "");
                text = text.Replace("/r", "");

                // разбиваем текст на слова
                string[] words = text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                // создаем переменные для подсчета количества слов
                int count_one = 0;
                int count_two = 0;
                int count_three = 0;
                int count_four = 0;
                int count_five = 0;

                // запускаем потоки для каждого слова
                Parallel.ForEach(words, word =>
                {
                    if (word == readwords_one)
                    {
                        Interlocked.Increment(ref count_one);
                    }
                    else if (word == readwords_two)
                    {
                        Interlocked.Increment(ref count_two);
                    }
                    else if (word == readwords_three)
                    {
                        Interlocked.Increment(ref count_three);
                    }
                    else if (word == readwords_four)
                    {
                        Interlocked.Increment(ref count_four);
                    }
                    else if (word == readwords_five)
                    {
                        Interlocked.Increment(ref count_five);
                    }
                });

                // выводим результат
                string record_one = "Количество слов '" + readwords_one + "' в тексте: " + count_one;
                string record_two = "Количество слов '" + readwords_two + "' в тексте: " + count_two;
                string record_three = "Количество слов '" + readwords_three + "' в тексте: " + count_three;
                string record_four = "Количество слов '" + readwords_four + "' в тексте: " + count_four;
                string record_five = "Количество слов '" + readwords_five + "' в тексте: " + count_five;

                Console.WriteLine(record_one);
                Console.WriteLine(record_two);
                Console.WriteLine(record_three);
                Console.WriteLine(record_four);
                Console.WriteLine(record_five);

                //Записываем данные в файл
                StreamWriter writer = new StreamWriter(@"D:\Codding\C#\3.2 Параллельные потоки 2.0\file\Open.txt");
                writer.WriteLine(record_one);
                writer.WriteLine(record_two);
                writer.WriteLine(record_three);
                writer.WriteLine(record_four);
                writer.WriteLine(record_five);
                writer.Close();
            }

        }
    }
}