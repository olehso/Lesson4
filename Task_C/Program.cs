using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Для городов необходимо хранить:
//— название;
//— год основания;
//— площадь;
//— количество населения для каждого типа жителей.
//Для типов жителей необходимо хранить:
//— город проживания;
//— название;
//— язык общения.
//Вывести информацию обо всех жителях заданного города, разговаривающих на заданном языке.
//Вывести информацию обо всех городах, в которых проживают жители выбранного типа.
//Вывести информацию о городе с заданным количеством населения и всех типах жителей, в нем проживающих.
//Вывести информацию о самом древнем типе жителей.

namespace Task_C
{
    class Program
    {
        static void Menu(int choice, ref Classes.Cities[] arrayCity)
        {
            do
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1 - Вывести информацию обо всех жителях заданного города, разговаривающих на заданном языке" +
                                  "\n2 - Вывести информацию обо всех городах, в которых проживают жители выбранного типа" +
                                  "\n3 - Вывести информацию о городе с заданным количеством населения и всех типах жителей, в нем проживающих" +
                                  "\n4 - Вывести информацию о самом древнем типе жителей" + 
                                  "\n5 - Вывести информацию о городах " + 
                                  "\n0 - выйти\n");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Base.DisplayInformationAboutAllTypesOfResidence(arrayCity);
                        break;
                    case 2:
                        Base.DisplayingInformationAboutAllCities(arrayCity);
                        break;
                    case 3:
                        Base.DisplayingCityInformation(arrayCity);
                        break;
                    case 4:
                        Base.DisplayingAncientTypeInformation(arrayCity);
                        break;
                    case 5:
                        if (arrayCity.Length > 0)
                        {
                            for (int i = 0; i < arrayCity.Length; i++)
                            {
                                arrayCity[i].DisplayInformationCities();
                                arrayCity[i].DisplayInformationTypesOfResidence();
                            }
                        }
                        else Console.WriteLine("Нет информации о городах!");
                        break;
                    default: break;
                }
            } while (choice != 0);
        }

        static void Main(string[] args)
        {
            int choice = 0;           

            Classes.Cities[] arrayCityDefault = new Classes.Cities[7];
            arrayCityDefault[0] = new Classes.Cities("Харьков", 1654, 350.2, 1443000,
                new Classes.TypesOfResidence("Харьков", "Харьковчане", "Украинский"));
            arrayCityDefault[1] = new Classes.Cities("Нью-Йорк", 1624, 783.8, 8419000,
                new Classes.TypesOfResidence("Нью-Йорк", "Нью-Йоркцы", "Английский"));
            arrayCityDefault[2] = new Classes.Cities("Москва", 1157, 2561.5, 12655000,
                new Classes.TypesOfResidence("Москва", "Москвечи", "Русский"));
            arrayCityDefault[3] = new Classes.Cities("Токио", 1457, 2193.96, 14100000,
                new Classes.TypesOfResidence("Токио", "Токийцы", "Японский"));
            arrayCityDefault[4] = new Classes.Cities("Мексика", 1325, 1680.00, 9100000,
                new Classes.TypesOfResidence("Мексика", "Мексиканцы", "Испанский"));
            arrayCityDefault[5] = new Classes.Cities("Рим", 753, 1287.36, 2871000,
                new Classes.TypesOfResidence("Рим", "Римляне", "Итальянский"));
            arrayCityDefault[6] = new Classes.Cities("Манчестер", 1301, 115.6, 553230,
                new Classes.TypesOfResidence("Манчестер", "Манчестерцы", "Английский"));
            Console.Clear();
            Menu(choice, ref arrayCityDefault);
        }
    }
}