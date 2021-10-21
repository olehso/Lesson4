using System;
using System.Collections.Generic;

//Точки.В сущностях(типах) хранится некоторое конечное множество точек с их координатами.
//Вывести точку из множества, наиболее приближенную к заданной.
//Вывести точку из множества, наиболее удаленную от заданной.
//Вывести точки из множества, лежащие на одной прямой с заданной прямой.

namespace Task_B
{
    public class Points
    {
        //Набор точек
        List<(int, int)> setOfPoints = new List<(int, int)>();
        //Добавление новых точек 
        public void AddNewPoint(int X, int Y)
        {
            setOfPoints.Add((X, Y));
        }
        //Поиск наиболее приближенной и отдаленной точек
        public void MinMaxDistance(int X, int Y)
        {
            (int, int) Point = (X, Y); //Исходная точка
            double MinDistance = Math.Sqrt(Math.Pow(Point.Item1 - setOfPoints[0].Item1, 2) + Math.Pow(Point.Item2 - setOfPoints[0].Item2, 2));
            double MaxDistance = MinDistance;

            int index0 = 0, index1 = 0; //Индексы для отдаленной и приближенной точек

            for (int i = 1; i < setOfPoints.Count; i++)
            {
                double tmp = Math.Sqrt(Math.Pow(Point.Item1 - setOfPoints[i].Item1, 2) + Math.Pow(Point.Item2 - setOfPoints[i].Item2, 2));
                //Поиск наиболее приближенной точки
                if (tmp < MinDistance)
                {
                    MinDistance = tmp;
                    index0 = i;
                }
                //Поиск наиболее отдаленной точки
                if (tmp > MaxDistance)
                {
                    MaxDistance = tmp;
                    index1 = i;
                }
            }
            Console.WriteLine($"Точка, которая наиболее приближена к заданной {Point.Item1}, {Point.Item2} - это {setOfPoints[index0].Item1}, {setOfPoints[index0].Item2}");
            Console.WriteLine($"Расстояние между точками {MinDistance}\n");
            Console.WriteLine($"Точка, которая наиболее отдалена от {Point.Item1}, {Point.Item2} - это {setOfPoints[index1].Item1}, {setOfPoints[index1].Item2}");
            Console.WriteLine($"Расстояние между точками {MaxDistance}");
        }

        //Вывод всех возможных точек
        public void Print()
        {
            Console.WriteLine("  ТОЧКИ");
            for (int i = 0; i < setOfPoints.Count; i++) Console.WriteLine($"X, Y: {setOfPoints[i].Item1}, {setOfPoints[i].Item2}");
        }

        //Поиск точек, лежащик на одной прямой с заданной прямой
        public void FindLine((int, int) PointA, (int, int) PointB)
        {
            double dist = Math.Sqrt(Math.Pow(PointB.Item1 - PointA.Item1, 2) + Math.Pow(PointB.Item2 - PointA.Item2, 2));
            Console.WriteLine($"Прямая {PointA.Item1}, {PointA.Item2} - {PointB.Item1}, {PointB.Item2}");

            for (int i = 0; i < setOfPoints.Count; i++)
            {
                //Определение длины отрезков
                double AB = Math.Sqrt(Math.Pow(setOfPoints[i].Item1 - PointA.Item1, 2) + Math.Pow(setOfPoints[i].Item2 - PointA.Item2, 2));
                double BC = Math.Sqrt(Math.Pow(PointB.Item1 - setOfPoints[i].Item1, 2) + Math.Pow(PointB.Item2 - setOfPoints[i].Item2, 2));
                if (AB + BC == dist)
                    Console.WriteLine($"Точка {setOfPoints[i].Item1}, {setOfPoints[i].Item2} лежит на прямой AC");
            }
        }

        static void Main(string[] args)
        {
            Points points = new Points();
            points.AddNewPoint(3, 7);
            points.AddNewPoint(6, 2);
            points.AddNewPoint(11, 7);
            points.Print();
            Console.WriteLine();
            points.MinMaxDistance(5, 1);
            Console.WriteLine();
            points.FindLine((0, 7), (12, 7));
            Console.ReadKey();
        }
    }
}
