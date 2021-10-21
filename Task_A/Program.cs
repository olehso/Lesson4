using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TaskA
{
    class Function
    {
        //Программа принимает строку.
        //По нажатию произвольной клавиши поочередно выделяет в тексте заданное слово(заданное слово вводится с клавиатуры);
        //Ищет в ней глаголы и возвращает в консоль строку без глаголов.
        //Для выполнения задания создать массив строк и проинициализировать его несколькими окончаниями, которые есть у глаголов, например, “ать”, “ять” и т.д.Слово из входной строки соответствует глаголу, если оно содержит одно из этих окончаний.
        //Найти во входной строке слова с одинаковым основанием (совпадающие части двух и более слов, 3 буквы и более) и разбить эти слова на 3 части
        //– префикс, то что стоит до основания слева,
        //– основа, то что совпадает с частью другого слова,
        //– окончание.
        //Обратите внимание, что некоторые из этих 1,3 частей могут отсутствовать.

        //Метод для реализации выделения заданного слова
        public static string[] Highlighting(string text, string word)
        {
            //Разделение строки на массив подстрок
            string[] arrayOfWords = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string txt in arrayOfWords)
            {
                if (string.Compare(txt, word, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(txt + " ");
                    Console.ResetColor();
                }
                else Console.Write(txt + " ");
            }
            return arrayOfWords;
        }

        //Метод для реализации удаления глаголов из строки
        public static void RemoveVerbsFromText(string[] text)
        {
            //Масиив окончаний глаголов
            string[] endsOfVerbs = { "ешь", "еть", "ем", "ете", "уть", "ють", "ишь", "ить", "им", "ите", "ать", "ять", "еть", "ыть", "оть", "ит", "ут", "ат", "ят", "ют", "сть" };
            StringBuilder stringBuilder = new StringBuilder();

            bool isVerb = false;

            //Проход по словам в массиве строк
            foreach (string word in text)
            {
                //Проход по окончаниям в массиве окончаний
                foreach (string ending in endsOfVerbs)
                {
                    if (word.EndsWith(ending))
                    {
                        isVerb = true;
                        break;
                    }
                }
                if (!isVerb) stringBuilder.Append(word + " ");
            }
            Console.Write("\nСтрока без глаголов: " + stringBuilder);
        }

        //Метод для передачи слов на сравнение на одинаковые основания
        public static void FindBaseWords(string[] text)
        {
            StringBuilder stringBuilder = new StringBuilder("");
            StringBuilder temp = new StringBuilder("");

            for (int i = 0; i < text.Length - 1; i++)
            {
                for (int j = i + 1; j < text.Length; j++)
                {
                    stringBuilder.Append(FindBase(text[i], text[j]) ?? temp);
                }
            }
            if (stringBuilder.Length == 0) Console.WriteLine("\nОдинаковых оснований нет!");
        }

        //Метод для проверки 2 слов на одинаковые основания
        static StringBuilder FindBase(string first, string second)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder basisWord = new StringBuilder();

            int count = 0;
            bool varification = false, clean = true;

            //Проход и сравнение букв в каждом слове
            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    if (first[i] != second[j])
                    {
                        if (!varification)
                        {
                            basisWord.Clear();
                        }
                        else if (varification && basisWord.Length > 2) clean = false;
                        count = 0;
                        continue;
                    }
                    else
                    {
                        count++;
                        if (clean) basisWord.Append(second[j]);
                        if (count == 3)
                        {
                            stringBuilder.Append(first + " ").Append(second);
                            varification = true;
                            Console.WriteLine("\n\n\t\tСлово с одинаковым основанием:");
                            Console.Write(stringBuilder);
                        }
                        if (i < first.Length - 1 && j < second.Length)
                        {
                            i++;
                            continue;
                        }
                    }
                    if (count < 1 && (i == first.Length - 2 || j == second.Length - 2)) break;
                }
            }
            if (varification) ParseWord(stringBuilder, basisWord);
            return stringBuilder;
        }

        //Метод разбиение слова на префикс, основание, окончание
        static void ParseWord(StringBuilder stringBuilder, StringBuilder basisWord)
        {
            Console.WriteLine("\nПрефикс\t\t\tОснование\t\tОкончание");

            string firstPref, firstEnd, secondPref, secondEnd;
            string text = stringBuilder.ToString();
            firstPref = text.Substring(0, text.IndexOf(basisWord.ToString()));
            firstEnd = text.Substring(firstPref.Length + basisWord.Length, text.IndexOf(" ") - firstPref.Length - basisWord.Length);

            Verification(firstPref);
            Console.Write($"{basisWord}\t\t\t");
            Verification(firstEnd);

            Console.WriteLine();
            secondPref = text.Substring(text.IndexOf(" ") + 1, text.LastIndexOf(basisWord.ToString()) - (text.IndexOf(" ") + 1));
            secondEnd = text.Substring(text.LastIndexOf(basisWord.ToString()) + basisWord.Length);
            Verification(secondPref);
            Console.Write($"{basisWord}\t\t\t");
            Verification(secondEnd);
        }

        //Метод проверки на пустоту строки и выведение частей слова
        static void Verification(string ch)
        {
            if (string.IsNullOrEmpty(ch)) Console.Write("-----\t\t\t");
            else Console.Write($"{ch}\t\t\t");

        }

        static void Main(string[] args)
        {
            Console.Write("Введите исходную строку: ");
            string text = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите слово: ");
            string word = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Нажмите ПРОИЗВОЛЬНУЮ клавишу для выделения необходимого слова!");
            Console.ReadKey();
            Console.WriteLine();

            Console.Write("Строка с выделенным словом: ");
            string[] arrayOfWords = Highlighting(text, word);
            Console.WriteLine();
            RemoveVerbsFromText(arrayOfWords);
            FindBaseWords(arrayOfWords);
        }
    }
}