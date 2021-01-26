using System;

namespace classes
{
	public class Student
	{
		//Так объявляется поле класса. Оно не статическое, т.е. не является глобальной переменной.
		public int Age;
		public string FirstName;
		public string LastName;
	}
	public class Program
	{
		//мы можем создать массив из Student, потому что Student — это такой же тип, как string или int
		static Student[] students;

		//Этот тип можно использовать в аргументах метода. 
		//Если мы захотим добавить новое поле в Student, не придется переписывать заголовок метода
		static void PrintStudent(Student student)
		{
			Console.WriteLine("{0,-15}{1}", student.FirstName, student.LastName);
		}

		static void Main()
		{
			students = new Student[2];

			//Классы — это ссылочные типы, их нужно инициализировать.
			students[0] = new Student();
			students[0].FirstName = "John";
			students[0].LastName = "Jones";
			students[0].Age = 19;
			students[1] = new Student();
			students[1].FirstName = "William";
			students[1].LastName = "Williams";
			students[1].Age = 18;

			//сокращенно — то же самое
			students = new[]
			{
			new Student { LastName = "Jones", FirstName = "John" },
			new Student { LastName = "Williams", FirstName = "William" }
			};

		}

		//какой то код, мейн его надо в класс программ закинуть
		static void Main1()
		{
			var city = new City();
			city.Name = "Ekaterinburg";
			city.Location = new GeoLocation();
			city.Location.Latitude = 56.50;
			city.Location.Longitude = 60.35;
			Console.WriteLine("I love {0} located at ({1}, {2})",
				city.Name,
				city.Location.Longitude.ToString(),
				city.Location.Latitude.ToString());
		}
		class City
		{
			public string Name;
			public GeoLocation Location;
		}
		class GeoLocation
		{
			public double Latitude;
			public double Longitude;
		}

		//программу с оконным интерфейсом, надо реализовать инициализацию меню
		//Для каждого пункта меню указывается название, горячая клавиша (далее указана в скобках) и список подменю(null, если подменю нет)
		//На верхнем уровне должно находиться два пункта: File(F) и Edit(E).
		//Меню Edit(E) должно содержать команды Copy(C) и Paste(V).
		public class MenuItem
		{
			public string Caption;
			public string HotKey;
			public MenuItem[] Items;
		}
		public static MenuItem[] GenerateMenu()
		{
			return new[]
			{
				new MenuItem
				{
					Caption = "File",
					HotKey = "F",
					Items = new[]
					{
						new MenuItem { Caption = "New", HotKey = "N" },
						new MenuItem { Caption = "Save", HotKey = "S" }
					}
				},

				new MenuItem
				{
					Caption = "Edit",
					HotKey = "E",
					Items = new[]
					{
						new MenuItem { Caption = "Copy", HotKey = "C" },
						new MenuItem { Caption = "Paste", HotKey = "V" }
					}
				}
			};
		}

		//статическое поле
		public class RightTriangle
		{
			public double Hypothenuse;
			public double[] Cathetes;

			public static double AngleBetweenCathetes = Math.PI / 2; //статическое поле
		}

		public class Program2
		{
			static void Main()
			{
				// Создание объекта-треугольника.
				// RightTriangle — это тип данных, который определяет, какую информацию и как мы храним в файле о прямоугольном треугольнике
				// firstTriangle — это конкретная область памяти, отформатированная в соответствии с типом RightTriangle
				var firstTriangle = new RightTriangle();
				// Обращение к динамическому полю
				firstTriangle.Hypothenuse = 5;
				firstTriangle.Cathetes = new double[2];
				firstTriangle.Cathetes[0] = 3;
				firstTriangle.Cathetes[1] = 4;

				//Обращение к статическому полю
				Console.WriteLine(RightTriangle.AngleBetweenCathetes);

			}
		}

		//статич/динамический метод
		class Point
		{
			public int X;
			public int Y;

			public void Print()
			{
				Console.WriteLine("{0} {1}", X, Y);
			}
			public static void PrintPoint(Point point) //статический метод абсолютно идентичный динамическому
			{
				Console.WriteLine("{0} {1}", point.X, point.Y);
			}
		}
		public static void Main3()
		{
			var point = new Point { X = 1, Y = 2 };
			point.Print();
			Point.PrintPoint(point);
		}

		//
		class SomeClass
		{
			public static int s = 1; // общее поле для обоих объектов
			public int d = 1; //свое для каждого объекта
			public void Run()
			{
				Console.Write(s + " " + d + " "); // 1 1 2 1 3 2
				s++; d++;
			}
			public static void Main()
			{
				var object1 = new SomeClass();
				var object2 = new SomeClass();
				object1.Run();
				object2.Run();
				object1.Run();
			}
		}
	}

	//методы расширения
	public class Program3
	{
		static double MyNextDouble(Random rnd, double min, double max)
		{
			return rnd.NextDouble() * (max - min) + min;
		}

		static void Main()
		{
			var rnd = new Random();
			Console.WriteLine(MyNextDouble(rnd, 10, 20));
			Console.WriteLine(rnd.NextDouble(10, 20));
			var array = new int[] { 1, 2, 3, 4, 5 };
			array.Swap(0, 1);
		}
	}
	public static class RandomExtensions
	{
		public static double NextDouble(this Random rnd, double min, double max)
		{
			return rnd.NextDouble() * (max - min) + min;
		}
	}
	public static class ArrayExtensions
	{
		public static void Swap(this int[] array, int i, int j)
		{
			var t = array[i];
			array[i] = array[j];
			array[j] = t;
		}
	}
	//
	public class Program4
	{
		public static void Main4()
		{
			var arg1 = "100500";
			Console.Write(arg1.ToInt() + "42".ToInt()); // 100542
		}
	}
	public static class StringExtensions
	{
		public static double ToInt(this string str)
		{
			return int.Parse(str);
		}
	}

	//статичекмй класс
	static class StaticAlgorithm
	{
		static int temporalValue;
		static public int Run(int value)
		{
			var result = 0;
			for (temporalValue = 0; temporalValue <= value; temporalValue++)
				result += temporalValue;
			return result;
		}
	}
	class Algorithm
	{
		int temporalValue;

		public int Run(int value)
		{
			var result = 0;
			for (temporalValue = 0; temporalValue <= value; temporalValue++)
				result += temporalValue;
			return result;
		}
	}

	//Сравнение вызова статического алгоритма и алгоритма, оформленного в виде класса
	public class Program5
	{
		public static void Main()
		{
			StaticAlgorithm.Run(10);

			var algorithm = new Algorithm();
			algorithm.Run(10);
		}
	}
}
