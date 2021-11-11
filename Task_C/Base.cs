using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_C
{
    class Base
    {
        //Метод для вывода информации обо всех жителях заданного города, разговаривающих на заданном языке.
        public static void DisplayInformationAboutAllTypesOfResidence(Classes.Cities[] arrayCity)
        {
            Console.Write("Введите название города: ");
            string name = Console.ReadLine();
            Console.Write("Введите язык общения: ");
            string language = Console.ReadLine();
            bool flag = false;
            Console.WriteLine("Информация о жителях заданного города и языка: \n");
            //Обработка исключений
            try
            {
                for (int i = 0; i < arrayCity.Length; i++)
                {
                    if (arrayCity[i].CityOfResidence == name && arrayCity[i].Language == language)
                    {
                        arrayCity[i].DisplayInformationTypesOfResidence();
                        flag = true;
                    }
                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Названия города {name} или языка {language} нет!\n");
            }
        }

        //Метод для вывода информации обо всех городах, в которых проживают жители выбранного типа.
        public static void DisplayingInformationAboutAllCities(Classes.Cities[] arrayCity)
        {
            Console.Write("Введите название жителей: ");
            string name = Console.ReadLine();
            bool flag = false;
            Console.WriteLine("Информация o городах, в которых проживают жители выбранного типа: \n");
            //Обработка исключений
            try
            {
                for (int i = 0; i < arrayCity.Length; i++)
                {
                    if (arrayCity[i].Name == name)
                    {
                        arrayCity[i].DisplayInformationCities();
                        flag = true;
                    }
                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Названия жителей {name} нет!\n");
            }

        }

        //Метод для вывода информации о городе с заданным количеством населения и всех типах жителей, в нем проживающих.
        public static void DisplayingCityInformation(Classes.Cities[] arrayCity)
        {
            Console.Write("Введите точное количество населения: ");
            int population;
            while (!int.TryParse(Console.ReadLine(), out population))
            {
                Console.WriteLine("Ошибка! Неверный формат данных!");
            }
            bool flag = false;
            Console.WriteLine("Информация о городе с заданным количеством населения и всех типах жителей, в нем проживающих: \n");
            //Обработка исключений
            try
            {
                for (int i = 0; i < arrayCity.Length; i++)
                {
                    if (arrayCity[i].Population == population)
                    {
                        arrayCity[i].DisplayInformationCities();
                        arrayCity[i].DisplayInformationTypesOfResidence();
                        flag = true;
                    }
                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Города с населением {population} нет!\n");
            }
        }

        //Метод для вывода информации о самом древнем типе жителей.
        public static void DisplayingAncientTypeInformation(Classes.Cities[] arrayCity)
        {
            Console.WriteLine("Информация о самом древнем типе жителей: \n");
            //Обработка исключений
            try
            {
                int min = arrayCity[0].YearOfFoundation;
                for (int i = 0; i < arrayCity.Length; i++)
                {
                    min = min > arrayCity[i].YearOfFoundation ? arrayCity[i].YearOfFoundation : min;
                }
                for (int i = 0; i < arrayCity.Length; i++)
                {
                    if (min == arrayCity[i].YearOfFoundation)
                    {
                        arrayCity[i].DisplayInformationTypesOfResidence();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Самого древнего типа жителей нет!\n");
            }
        }
    }
}