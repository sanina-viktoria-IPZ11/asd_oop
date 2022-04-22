using System;
using System.Diagnostics;
namespace ConsoleApp1
{
    class Program
    {
        static void OutPut(ref int[] ArrayOne, ref int size)
        {
            //виведення утвореного масиву
            for (int i = 0; i < size; i++)
                Console.Write(ArrayOne[i] + "  ");
            Console.WriteLine("  ");
        }
        static void InputOfArray(ref int[] ArrayOne, ref int size)
        {

            int temporary;
            int min, max;
            bool conditionmin = true;
            bool conditionmax = true;
            //введення даних
            string conditionMinEdit;
            string conditionMaxEdit;

            Console.WriteLine("Введіть межі діапазону");
            conditionMinEdit = Console.ReadLine();
            conditionMaxEdit = Console.ReadLine();
            conditionmin = int.TryParse(conditionMinEdit, out min);
            conditionmax = int.TryParse(conditionMaxEdit, out max);

            if (conditionmax == false || conditionmin == false)
            { Console.WriteLine("Введіть доречну умову"); }
            else
            {
                ArrayOne = new int[size];
                if (min > max)
                {
                    temporary = min;
                    min = max;
                    max = temporary;
                }
                // Random - клас для генерації випадкових чисел
                Random aRand = new Random();
                // заповнення масиву
                for (int i = 0; i < size; i++)
                    ArrayOne[i] = aRand.Next(min, max);

                OutPut(ref ArrayOne, ref size);
            }

        }
        static void CratingOfArray(ref int[] ArrayOne, ref int size)
        {
            int variant;
            bool conditionone = true;
            bool conditiontwo = true;

            //введення даних
            string conditionOneEdit;
            string conditionTwoEdit;

            Console.WriteLine("Введіть кількість елементів масиву");
            conditionOneEdit = Console.ReadLine();
            conditionone = int.TryParse(conditionOneEdit, out size);

            Console.WriteLine("Сгенерувати елементи в заданому діапазоні(1) або ввести самостійно (2)");
            conditionTwoEdit = Console.ReadLine();
            conditiontwo = int.TryParse(conditionTwoEdit, out variant);

            if (conditiontwo == false || conditionone == false)
            { Console.WriteLine("Недоречна умова"); }
            else
            {
                size = int.Parse(conditionOneEdit);
                variant = int.Parse(conditionTwoEdit);
                if (variant == 1)
                {
                    InputOfArray(ref ArrayOne, ref size);
                }
                else if (variant == 2)
                {
                    string elementStr;
                    bool elementCheck = true;
                    int element;
                    for (int i = 0; i < size; i++)
                    {
                        do
                        {
                            elementStr = Console.ReadLine();
                            elementCheck = int.TryParse(elementStr, out element);
                            if (elementCheck == false) { Console.WriteLine("Недоречна умова"); }
                        } while (elementCheck == false);
                        ArrayOne[i] = element;
                    }
                    OutPut(ref ArrayOne, ref size);
                }
                else { Console.WriteLine("Недоречна умова"); }
            }
        }
        //пошук перебором елемента масиву, що дорівнює заданому значенню.
        static void SearchBySearch(ref int[] ArraySortOne, ref int size)
        {
            bool conditionone = true;
            //введення даних
            string conditionOneEdit;
            int root;
            int i = 0;
            int N;
            bool Found = false;
            Console.WriteLine("Введіть елемент, що потрібно знайти: ");
            conditionOneEdit = Console.ReadLine();
            conditionone = int.TryParse(conditionOneEdit, out root);
            if (conditionone == false)
            { Console.WriteLine("Недоречна умова"); }
            else
            {
                //клас для виміру часу, що минув
                Stopwatch stopWatch = new Stopwatch();
                //початок виміру часу
                stopWatch.Start();
                while ((i < size) && Found == false)
                {
                    if (ArraySortOne[i] == root)
                    {
                        N = i;
                        Console.WriteLine("Шуканий елемент на позиції: " + N);
                        Found = true;
                    }
                    i++;
                }
                if (i == size && Found == false) Console.WriteLine("Елемент не знайдено");
                //різниця між двома точками часу
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}.{1:00}", ts.Milliseconds, ts.Milliseconds / 100);
                stopWatch.Stop();
                Console.WriteLine("Використаний час: " + elapsedTime);
            }

        }
        //бар'єрний пошук елемента масиву, що дорівнює заданому значенню.
        static void BarrierSearch(ref int[] ArraySortOne, ref int size)
        {
            bool conditionone = true;
            int sizeForArray = size + 1;
            //введення даних
            string conditionOneEdit;
            int root;
            int iterator = 0;
            int N;
            bool Found = false;
            int[] arrayForBarrierSearch = new int[sizeForArray];
            //створення нового масива з розміром більшим на 1
            for (int i = 0; i < size; i++)
                arrayForBarrierSearch[i] = ArraySortOne[i];

            Console.WriteLine("Введіть елемент, що потрібно знайти: ");
            conditionOneEdit = Console.ReadLine();
            conditionone = int.TryParse(conditionOneEdit, out root);

            if (conditionone == false)
            { Console.WriteLine("Недоречна умова"); }
            else
            {
                //клас для виміру часу, що минув
                Stopwatch stopWatch = new Stopwatch();
                //початок виміру часу
                stopWatch.Start();
                //створення бар'єру
                arrayForBarrierSearch[size] = root;
                //виведення нового масива
                for (int i = 0; i < sizeForArray; i++)
                    Console.Write(arrayForBarrierSearch[i] + "  ");
                Console.WriteLine(" ");

                while ((iterator < sizeForArray) && !Found)
                {
                    if (arrayForBarrierSearch[iterator] == root)
                    {
                        N = iterator;
                        Console.WriteLine("Шуканий елемент на позиції: " + N);
                        Found = true;
                    }
                    iterator++;
                }
                //різниця між двома точками часу
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}.{1:00}", ts.Milliseconds, ts.Milliseconds / 100);
                stopWatch.Stop();
                Console.WriteLine("Використаний час: " + elapsedTime);
            }
        }
        //бінарний пошук елемента масиву, що дорівнює заданому значенню.
        static int BinSearch(ref int[] ArraySortOne, ref int size)
        {
            int temp; //тимчасова змінна

            // сортування бульбашкою
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (ArraySortOne[j] > ArraySortOne[j + 1])
                    {
                        // поміняти елементи мсцями
                        temp = ArraySortOne[j];
                        ArraySortOne[j] = ArraySortOne[j + 1];
                        ArraySortOne[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < size; i++)
                Console.Write(ArraySortOne[i] + "  ");
            Console.WriteLine(" ");

            bool conditionone = true;
            //введення даних
            string conditionOneEdit;
            int root;
            int leftBarrier = 0;
            int rightBarrie = size;
            bool Found = false;
            int middle = 0;
            int result = 0;
            int b = 0;
            Console.WriteLine("Введіть елемент, що потрібно знайти: ");
            conditionOneEdit = Console.ReadLine();
            conditionone = int.TryParse(conditionOneEdit, out root);

            if (conditionone == false)
            { Console.WriteLine("Недоречна умова"); return 0; }
            else
            {
                //клас для виміру часу, що минув
                Stopwatch stopWatch = new Stopwatch();
                //початок виміру часу
                stopWatch.Start();
                while ((leftBarrier <= rightBarrie) && Found == false)
                {
                    middle = (int)((leftBarrier + rightBarrie) / 2);
                    if (ArraySortOne[middle] == root) Found = true;
                    else if (ArraySortOne[middle] < root) leftBarrier = middle + 1;
                    else rightBarrie = middle - 1;
                }
                if (Found == true) Console.WriteLine("Шуканий елемент на позиції: " + middle);
                else Console.WriteLine("Шуканий елемент не знайдено");
                //різниця між двома точками часу
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}.{1:00}", ts.Milliseconds, ts.Milliseconds / 100);
                stopWatch.Stop();
                Console.WriteLine("Використаний час: " + elapsedTime);
                return 0;
            }
        }
        //бінарний пошук з золотим перерізом, що дорівнює заданому значенню.
        static void BinSearchGoldenRatio(ref int[] ArraySortOne, ref int size)
        {
            bool conditionone = true;
            //введення даних
            string conditionOneEdit;
            int root;
            int leftBarrier = 0;
            int rightBarrie = size - 1;
            bool Found = false;
            int middle = 0;
            double goldenRatio = (Math.Sqrt(5) + 1) / 2;
            int temp;

            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (ArraySortOne[j] > ArraySortOne[j + 1])
                    {
                        // меняем элементы местами
                        temp = ArraySortOne[j];
                        ArraySortOne[j] = ArraySortOne[j + 1];
                        ArraySortOne[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < size; i++)
                Console.Write(ArraySortOne[i] + "  ");
            Console.WriteLine(" ");

            Console.WriteLine("Введіть елемент, що потрібно знайти: ");
            conditionOneEdit = Console.ReadLine();
            conditionone = int.TryParse(conditionOneEdit, out root);

            if (conditionone == false)
            { Console.WriteLine("Недоречна умова"); }
            else
            {
                //клас для виміру часу, що минув
                Stopwatch stopWatch = new Stopwatch();
                //початок виміру часу
                stopWatch.Start();
                while ((leftBarrier <= rightBarrie) && Found == false)
                {
                    middle = (int)((leftBarrier + rightBarrie * goldenRatio) / goldenRatio);
                    if (ArraySortOne[middle] == root) Found = true;
                    else if (ArraySortOne[middle] < root) leftBarrier = middle + 1;
                    else rightBarrie = middle - 1;
                }
                if (Found == true) Console.WriteLine("Шуканий елемент на позиції: " + middle);
                else Console.WriteLine("Шуканий елемент не знайдено");
                //різниця між двома точками часу
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}.{1:00}", ts.Milliseconds, ts.Milliseconds / 100);
                stopWatch.Stop();
                Console.WriteLine("Використаний час: " + elapsedTime);
            }
        }
        //головна функція
        static void Main(string[] args)
        {
            int[] array = new int[100000];
            int size = 0;
            bool inputcheck = false;

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("==============================================");
            Console.WriteLine("    Лабораторна робота 1");
            Console.WriteLine(" Саніна Вікторія Олександрівна");
            Console.WriteLine("         ІПЗ-11.2");
            double n = 0;
            do
            {
                Console.WriteLine("=====================Меню=====================");
                Console.WriteLine("  1. Створити масив");
                Console.WriteLine("  2. Лінійний пошук у масиві");
                Console.WriteLine("  3. Бар'єний пошук у масиві");
                Console.WriteLine("  4. Бінарний пошук");
                Console.WriteLine("  5. Бінарний пошук методом золотого перерізу");
                Console.WriteLine("  6. Лінійний пошук у списку");
                Console.WriteLine("  7. Бар'єний пошук у списку");
                Console.WriteLine("  8. Завершити роботу");
                Console.WriteLine("==============================================");

                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.InputEncoding = System.Text.Encoding.Unicode;

                string condition = Console.ReadLine();
                int.TryParse(condition, out int cond);
                if (cond == 0) { Console.WriteLine("Введіть доречну умову"); }
                else
                {
                    n = double.Parse(condition);
                    switch (n)
                    {
                        case 1: { CratingOfArray(ref array, ref size); inputcheck = true; } break;
                        case 2:
                            {
                                if (n == 2 && inputcheck == false)
                                {
                                    Console.WriteLine("Спочатку необхідно створити масив");
                                    CratingOfArray(ref array, ref size);
                                    inputcheck = true;
                                }
                                Console.WriteLine("----------------------------------------------");
                                OutPut(ref array, ref size);
                                SearchBySearch(ref array, ref size);
                            }
                            break;
                        case 3:
                            {
                                if (n == 3 && inputcheck == false)
                                {
                                    Console.WriteLine("Спочатку необхідно створити масив");
                                    CratingOfArray(ref array, ref size);
                                    inputcheck = true;
                                }
                                Console.WriteLine("----------------------------------------------");
                                OutPut(ref array, ref size);
                                BarrierSearch(ref array, ref size);
                            }
                            break;
                        case 4:
                            {
                                if (n == 4 && inputcheck == false)
                                {
                                    Console.WriteLine("Спочатку необхідно створити масив");
                                    CratingOfArray(ref array, ref size);
                                    inputcheck = true;
                                }
                                Console.WriteLine("----------------------------------------------");
                                OutPut(ref array, ref size);
                                Console.WriteLine("----------------------------------------------");
                                BinSearch(ref array, ref size);
                            }
                            break;
                        case 5:
                            {
                                if (n == 5 && inputcheck == false)
                                {
                                    Console.WriteLine("Спочатку необхідно створити масив");
                                    CratingOfArray(ref array, ref size);
                                    inputcheck = true;
                                }
                                Console.WriteLine("----------------------------------------------");
                                OutPut(ref array, ref size);
                                Console.WriteLine("----------------------------------------------");
                                BinSearchGoldenRatio(ref array, ref size);
                            }
                            break;
                        case 6:
                            {
                                if (n == 6 && inputcheck == false)
                                {
                                    Console.WriteLine("Спочатку необхідно створити список");
                                    CratingOfArray(ref array, ref size);
                                    inputcheck = true;
                                }
                                Console.WriteLine("----------------------------------------------");
                                OutPut(ref array, ref size);
                                GetList(array);
                            }
                            break;
                        case 7:
                            {
                                if (n == 7 && inputcheck == false)
                                {
                                    Console.WriteLine("Спочатку необхідно створити список");
                                    CratingOfArray(ref array, ref size);
                                    inputcheck = true;
                                }
                                Console.WriteLine("----------------------------------------------");
                                OutPut(ref array, ref size);
                                LinkedListBarrier(array);
                            }
                            break;
                        default: Console.WriteLine("Введіть доречну умову"); break;
                    }
                }
            } while (n != 8);
            Console.ReadLine();
        }
        //введення списку
        private static LinkedList GetList(int[] array)
        {
            int i = array.Length - 1;
            var last = new LinkedList(array[i], null);
            while (i > 0)
            {
                i--;
                var temp = new LinkedList(array[i], last);
                last = temp;
            }
            var current = new LinkedList(array[i], null);
            ListSearch(array, last, last);
            return last;
        }
        //додання елемента в список
        private static LinkedList LinkedListBarrier(int[] array)
        {
            bool conditionone = true;
            //введення даних
            string conditionOneEdit;
            int root;

            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("Введіть елемент, що потрібно знайти: ");
            conditionOneEdit = Console.ReadLine();
            conditionone = int.TryParse(conditionOneEdit, out root);

            var last = new LinkedList(root, null);

            if (conditionone == false)
            { Console.WriteLine("Недоречна умова"); }
            else
            {
                //створення масива з новим елементом
                int i = array.Length - 1;
                last = new LinkedList(root, null);
                var temp = new LinkedList(array[i], last);
                last = temp;
                temp = new LinkedList(array[i], last);

                while (i > 0)
                {
                    i--;
                    temp = new LinkedList(array[i], last);
                    last = temp;
                }

                BarrierSearchList(array, last, last, root);

            }
            return last;
        }
        //пошук перебором елемента списку, що дорівнює заданому значенню.
        public static void ListSearch(int[] array, LinkedList current, LinkedList head)
        {
            bool conditionone = true;
            //введення даних
            string conditionOneEdit;
            int root;
            int i = 0;
            Console.WriteLine("Введіть елемент, що потрібно знайти: ");
            conditionOneEdit = Console.ReadLine();
            conditionone = int.TryParse(conditionOneEdit, out root);
            if (conditionone == false)
            { Console.WriteLine("Недоречна умова"); }
            else
            {
                //клас для виміру часу, що минув
                Stopwatch stopWatch = new Stopwatch();
                //початок виміру часу
                stopWatch.Start();
                int g = 0, position = -1;
                bool isFound = false;
                var iterator = head;
                LinkedList index = null;
                index = current.Next;
                while (iterator != null && isFound == false)
                {
                    if (iterator.Data == root)
                    {
                        position = g;
                        isFound = true;
                    }
                    g++;
                    iterator = iterator.Next;
                }

                Console.WriteLine("Елемент за індексом: " + position);
                //різниця між двома точками часу
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}.{1:00}", ts.Milliseconds, ts.Milliseconds / 100);
                stopWatch.Stop();
                Console.WriteLine("Використаний час: " + elapsedTime);
            }
        }
        //бар'єрний пошук елемента списку, що дорівнює заданому значенню.
        static void BarrierSearchList(int[] array, LinkedList current, LinkedList head, int root)
        {

            //клас для виміру часу, що минув
            Stopwatch stopWatch = new Stopwatch();
            //початок виміру часу
            stopWatch.Start();
            {
                int g = 0, position = -1;
                bool isFound = false;
                var iterator = head;
                LinkedList index;
                index = current.Next;
                while (iterator != null && !isFound)
                {
                    if (iterator.Data == root)
                    {
                        position = g;
                        isFound = true;
                    }
                    g++;
                    iterator = iterator.Next;
                }
                Console.WriteLine("Елемент за індексом: " + position);
            }
            //різниця між двома точками часу
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}.{1:00}", ts.Milliseconds, ts.Milliseconds / 100);
            stopWatch.Stop();
            Console.WriteLine("Використаний час: " + elapsedTime);
        }
    }
}