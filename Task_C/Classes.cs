using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_C
{
    class Classes
    {
        //Класс типа жителей
        public class TypesOfResidence
        {
            //Поля
            public string CityOfResidence { get; }
            public string Name { get; }
            public string Language { get; }

            //Конструктор
            public TypesOfResidence(string cityOfResidence, string name, string language)
            {
                CityOfResidence = cityOfResidence;
                Name = name;
                Language = language;
            }
        }

        //Класс городов
        public class Cities
        {
            //Создание экземляра класса типа жителей для примера агрегации
            TypesOfResidence _typesOfResidence;

            //Поля
            public string CitiesName { get; set; }
            public int YearOfFoundation { get; set; }
            public double Square { get; set; }
            public int Population { get; set; }

            //Конструктор по умолчанию
            public Cities() { }

            //Конструктор
            public Cities(string citiesName, int yearOfFoundation, double square, int population, TypesOfResidence someTypesOfResidents)
            {
                CitiesName = citiesName;
                YearOfFoundation = yearOfFoundation;
                Square = square;
                Population = population;
                _typesOfResidence = someTypesOfResidents;
            }
            public string CityOfResidence
            {
                get { return _typesOfResidence.CityOfResidence; }
            }
            public string Name
            {
                get { return _typesOfResidence.Name; }
            }
            public string Language
            {
                get { return _typesOfResidence.Language; }
            }
            public void DisplayInformationCities()
            {
                Console.WriteLine("----------ГОРОД-----------");
                Console.WriteLine($"Название города: {CitiesName}");
                Console.WriteLine($"Год основания: {YearOfFoundation}");
                Console.WriteLine($"Площадь: {Square}");
                Console.WriteLine($"Количество населения: {Population}");
                Console.WriteLine("--------------------------");
            }
            public void DisplayInformationTypesOfResidence()
            {
                Console.WriteLine("-------ТИП ЖИТЕЛЕЙ---------");
                Console.WriteLine($"Город проживания: {_typesOfResidence.CityOfResidence}");
                Console.WriteLine($"Название: {_typesOfResidence.Name}");
                Console.WriteLine($"Язык общения: {_typesOfResidence.Language}");
                Console.WriteLine("--------------------------\n");
            }
        }
    }
}