using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab_14
{
    class Program
    {
        private static void Cars_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    car newCar = e.NewItems[0] as car;
                    Console.WriteLine($"Добавлена машина, скорость:{newCar.speed} масса:{newCar.mass} потребление:{newCar.consumption} ");
                    break;
                case NotifyCollectionChangedAction.Remove: 
                    car oldCar = e.OldItems[0] as car;
                    Console.WriteLine($"Удалена машина, скорость:{oldCar.speed} масса:{oldCar.mass} потребление:{oldCar.consumption} ");
                    break;               
            }
        }

        static public void zad1()
        {
            ArrayList ArList = new ArrayList();
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                ArList.Add(rand.Next() % 100);
            }

            ArList.Add("Hello world");

            Console.WriteLine($"количество элементов ArrayList - {ArList.Count}");
            Console.WriteLine("список элементов ArrayList");
            foreach (object o in ArList)
                Console.WriteLine(o);

            Console.WriteLine();

            int ind = 2;
            ArList.RemoveAt(ind);
            Console.WriteLine($"Удален элемент с индексом { ind }");
            Console.WriteLine();

            Console.WriteLine($"количество элементов ArrayList - {ArList.Count}");
            Console.WriteLine("список элементов ArrayList");
            foreach (object o in ArList)
                Console.WriteLine(o);

            Console.WriteLine();

            object T = "Hello world";
            Console.WriteLine($"Индекс элемента { Convert.ToString(T) } в ArrayList - {ArList.IndexOf(T)}");

            Console.ReadKey();
        }

        static public void zad2()
        {
            Queue<int> Q = new Queue<int>();

            Random rand = new Random();

            for (int i = 0; i < 8; i++)
            {
                Q.Enqueue(rand.Next() % 100);
            }

            Console.WriteLine("Элементы Queue");
            foreach (int val in Q)
                Console.Write($"{val} ");
            Console.WriteLine("\n");

            int n = 3;
            for (int i = 0; i < n; i++)
                Q.Dequeue();

            Console.WriteLine($"Удалено { n } элементов Queue");
            Console.WriteLine();

            Console.WriteLine("Элементы Queue");
            foreach (int val in Q)
                Console.Write($"{val} ");
            Console.WriteLine("\n");

            Dictionary<int, int> Dic = new Dictionary<int, int> { };

            foreach (int i in Q)
                Dic.Add(rand.Next() % 10000, i);

            Console.WriteLine("Элементы Dictionary");
            foreach (KeyValuePair<int, int> val in Dic)
                Console.WriteLine($"Ключ - {val.Key} | Значение - {val.Value}");
            Console.WriteLine();

            Console.WriteLine("--Введите ключ для поиска значения в словаре--");
            int key = Convert.ToInt32(Console.ReadLine());
            if (Dic.TryGetValue(key, out int value))
                Console.WriteLine($"Ключу { key } соответствует элемент { value }");
            else
                Console.WriteLine("Заданный ключ не найден");

            Console.ReadKey();
        }

        static public void zad3()
        {
            Queue<car> Q = new Queue<car>();
            List<car> L = new List<car>();

            Random rand = new Random();

            for (int i = 0; i < 8; i++)
            {
                Q.Enqueue(new car(rand.Next() % 50, Math.Round(rand.NextDouble(), 3), rand.Next() % 50));
            }

            Console.WriteLine("Элементы Queue");
            foreach (car val in Q)
                Console.WriteLine($"скорость:{val.speed} масса:{val.mass} потребление:{val.consumption} ");
            Console.WriteLine("\n");

            int n = 3;
            for (int i = 0; i < n; i++)
                Q.Dequeue();

            Console.WriteLine($"Удалено { n } элементов Queue");
            Console.WriteLine();

            Console.WriteLine("Элементы Queue");
            foreach (car val in Q)
                Console.WriteLine($"скорость:{val.speed} масса:{val.mass} потребление:{val.consumption} ");
            Console.WriteLine("\n");

            Dictionary<int, car> Dic = new Dictionary<int, car> { };

            foreach (car i in Q)
            {
                Dic.Add(rand.Next() % 10000, i);
                L.Add((car)i.Clone()); //Глубокое копирование
            }

            Console.WriteLine("Элементы Dictionary");
            foreach (KeyValuePair<int, car> val in Dic)
                Console.WriteLine($"Ключ - {val.Key} | Значение - [скорость:{val.Value.speed} масса:{val.Value.mass} потребление:{val.Value.consumption}]");
            Console.WriteLine();

            Console.WriteLine("--Введите ключ для поиска значения в словаре--");
            int key = Convert.ToInt32(Console.ReadLine());
            if (Dic.TryGetValue(key, out car value))
                Console.WriteLine($"Ключу { key } соответствует элемент [скорость:{value.speed} масса:{value.mass} потребление:{value.consumption}]");
            else
                Console.WriteLine("Заданный ключ не найден");
            Console.WriteLine();

            //Демонстрация работы интерфейсов IComparer и ICompareable
            L.Sort(new CarComparer());

            Console.WriteLine("Отсортированный список (по скорости)");
            foreach (car c in L)            
                Console.WriteLine($"скорость:{c.speed} масса:{c.mass} потребление:{c.consumption} ");
            Console.WriteLine();
            
            //Демонстрация работы интерфейса ICloneable
            Console.WriteLine("Поделим все значения массы в списке на 2");
            foreach (car c in L)
            {
                c.mass /= 2;
                Console.WriteLine($"скорость:{c.speed} масса:{c.mass} потребление:{c.consumption} ");               
            }
            Console.WriteLine();

            Console.WriteLine("Значения массы в первоначальной коллекции при этом остались прежними");
            foreach (car c in Q)
                Console.WriteLine($"скорость:{c.speed} масса:{c.mass} потребление:{c.consumption} ");
            Console.ReadKey();
        }

        static public void zad4()
        {
            ObservableCollection<car> cars = new ObservableCollection<car>
            {
                new car { mass = 1, consumption = 2, speed = 3},
                new car { mass = 2, consumption = 4, speed = 9},
                new car { mass = 3, consumption = 5, speed = 7},
                new car { mass = 4, consumption = 6, speed = 6},
                new car { mass = 5, consumption = 8, speed = 2},
            };

            foreach (car c in cars)
                Console.WriteLine($"скорость:{c.speed} масса:{c.mass} потребление:{c.consumption} ");
            Console.WriteLine();

            cars.CollectionChanged += Cars_CollectionChanged;

            cars.Add(new car(6, 6, 6));
            cars.RemoveAt(3);
            cars.Add(new car(8, 1, 1));

            Console.WriteLine();

            foreach (car c in cars)
                Console.WriteLine($"скорость:{c.speed} масса:{c.mass} потребление:{c.consumption} ");

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Console.WriteLine();
            zad1();

            Console.Clear();
            Console.WriteLine("Задание 2");
            Console.WriteLine();
            zad2();

            Console.Clear();
            Console.WriteLine("Задание 3");
            Console.WriteLine();
            zad3();

            Console.Clear();
            Console.WriteLine("Задание 4");
            Console.WriteLine();
            zad4();
        }
    }
}
