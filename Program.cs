using System;
using System.Threading;

namespace study
{
    class Program
    {
        public static void Main()
        {
            cyanColor();
        startPos: Console.WriteLine("Вас приветствует мастер создания двумерного массива!");

        question1: Console.WriteLine("Введите высоту вашего массива:");
            if (int.TryParse(Console.ReadLine(), out int length)) { }
            else
            {
                redColor();                                                       //создание переменной высоты массива, ввод высоты массива и ошибка в случае если пользователь введёт не int
                Console.WriteLine("Ошибка ввода, введите цифру!");
                timer3second();
                goto question1;
            }

        question2: Console.WriteLine("Введите ширину вашего массива:");
            if (int.TryParse(Console.ReadLine(), out int width)) { }
            else
            {
                redColor();                                //создание переменной ширины массива, ввод ширины массива и ошибка в случае если пользователь введёт не int
                Console.WriteLine("Ошибка ввода, введите цифру!");
                timer3second();
                goto question2;
            }

            int[,] userArray = new int[length, width];//создание массива

            arrayCreate(userArray, length, width);//цикл заполнения массива пользователем
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Массив успешно создан!\n");
            cyanColor(); 
        choice: Console.WriteLine("Нажмите w для вывода массива,\n" +
                "r для вывода массива и перезапуска программы,\n" +
                "d для поиска элемента массива по индексу массива,\n" +
                "z для поиска индекса по элементу,\n" +
                "любую другую клавишу для выхода.");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            switch (consoleKey)
            {
                case ConsoleKey.W:
                    Console.Clear();
                    arrayDisplay(userArray, length, width); //очистка консоли и вывод массива на экран
                    break;
                case ConsoleKey.R:
                    Console.Clear();
                    arrayDisplay(userArray, length, width); //очистка консоли и вывод массива на экран
                    timer(); //таймер
                    Console.Clear();
                    goto startPos;         //очистка консоли и последующий перезапуск программы
                case ConsoleKey.D:
                    arrayElementFind(userArray, length, width);
                    break;
                case ConsoleKey.Z: Console.Clear(); arrayIndexFind(userArray, length, width);
                    break;
                default: goto end;
            }

            Console.WriteLine("Нажмите s для перехода в меню выбора операции,\n" +
                "x для перезапуска программы,\n" +
                "любую другую клавишу для завершения работы программы.");
            consoleKey = Console.ReadKey().Key;
            switch (consoleKey)
            {
                case ConsoleKey.S: Console.Clear(); goto choice;                //финальный выбор после всех операций между перезапуском и переходм в меню выбора
                case ConsoleKey.X: Console.Clear(); goto startPos;
            }
        end:;
        }
        private static void arrayCreate(int[,] userArray, int length, int width)     //создаёт массив по данным пользователя с помощью цикла
        {
            int a = 1;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                arrayCreate:
                    Console.Clear();
                    Console.WriteLine("Введите {0} элемент массива:", a);
                    try { userArray[i, j] = int.Parse(Console.ReadLine()); }
                    catch
                    {
                        redColor();
                        Console.WriteLine("Ошибка ввода, введите цифру!");
                        timer3second();
                        goto arrayCreate;
                    }
                    a++;
                }
            }
        }
        private static void arrayDisplay(int[,] userArray, int length, int width)   //выводит массив в виде таблички в консоль с помощью цикла
        {
            magentaColor();
            for (int a = 0; a < length; a++)
            {
                for (int b = 0; b < width; b++)
                {
                    Console.Write(userArray[a, b] + "\t");
                }
                Console.WriteLine();
            }
            cyanColor();
        }
        private static void timer()    //таймер для перезапуска программы через 10 секунд
        {
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine("Программа перезапустится через {0} секунд(ы).", i);
                Thread.Sleep(1000);
            }
        }
        private static void timer3second()      //таймер 3 секунды (используется в программе для перезапуска после ошибки)
        {
            cyanColor();
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine("Повторите попытку через {0} секунд(ы).", i);
                Thread.Sleep(1000);
            }
            Console.Clear();
        }
        private static void cyanColor()         //меняет цвет консоли на голубой
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        private static void redColor()          //меняет цвет консли на красны (для ошибок)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        private static void magentaColor()      //меняет цвет консоли на фиолетовый (для успешного вывода результата на консоль)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        private static void arrayElementFind(int[,] userArray, int length, int width)      //находит элемент по индексу пользователя подробней внутри метода
        {
            int firstUserIndex;             //переменные в которые будет заполняться информация данная пользователем
            int secondUserIndex;
        firstIndexCreate: Console.Clear();
            Console.WriteLine("Введите индекс элемента по высоте(первый индекс):");
            try { firstUserIndex = int.Parse(Console.ReadLine()); }             //ввод пользователем первого индекса
            catch
            {
                redColor();
                Console.WriteLine("Ошибка ввода, введите цифру!");              //ошибка если ввод не интуется
                timer3second(); goto firstIndexCreate;
            }
            if (firstUserIndex >= length)
            {
                redColor();                                                     //ошибка если ввод выходит за массив 
                Console.WriteLine("Ошибка ввода, вы вышли за пределы массива, введи цифру от 0 до {0}!", length - 1);
                timer3second();
                goto firstIndexCreate;

            }
        secondIndexCreate: Console.Clear();
            Console.WriteLine("Введите индекс элемента по ширине(второй индекс):");
            try { secondUserIndex = int.Parse(Console.ReadLine()); }            //ввод пользователем первого индекса
            catch
            {
                redColor();
                Console.WriteLine("Ошибка ввода, введите цифру!");              //ошибка если ввод не интуется
                timer3second(); goto secondIndexCreate;
            }
            if (secondUserIndex >= width)
            {
                redColor();                                                     //ошибка если ввод выходит за массивы
                Console.WriteLine("Ошибка ввода, вы вышли за пределы массива, введи цифру от 0 до {0}!", width - 1);
                timer3second();
                goto secondIndexCreate;
            }
            magentaColor();
            Console.WriteLine("Элемент под индексом [{0}, {1}]: {2}.", firstUserIndex, secondUserIndex, userArray[firstUserIndex, secondUserIndex]);
            cyanColor();                                                        //вывод нужного пользователю элемента


        }
        private static int findSecondIndex(int[,] userArray, int userNumber, int length, int width)
        {
            for (int indexFirst = 0; indexFirst < length; indexFirst++)
            {
                for (int indexSecond = 0; indexSecond < width; indexSecond++)
                {
                    if (userArray[indexFirst, indexSecond] == userNumber)
                    {
                        return indexSecond;
                    }
                }
            }
            return -1;
        }   //идентичные методы но первый возвращает второй
        private static int findFirstIndex(int[,] userArray, int userNumber, int length, int width)
        {
            for (int indexFirst = 0; indexFirst < length; indexFirst++)
            {
                for (int indexSecond = 0; indexSecond < width; indexSecond++)
                {
                    if (userArray[indexFirst, indexSecond] == userNumber)
                    {
                        return indexFirst;
                    }
                }
            }
            return -1;
        }  // индекс, а второй - первый
        private static void arrayIndexFind(int[,] userArray, int length, int width)
        {
            int userNumber;
        startFind: Console.WriteLine("Введите число индекс которого хотите получить:");
            try { userNumber = int.Parse(Console.ReadLine()); }
            catch { redColor(); Console.WriteLine("Ошибка ввода, введите цифру!"); timer3second(); goto startFind; }
            Console.WriteLine("Индекс числа {0}: [{1}, {2}]", userNumber, findFirstIndex(userArray, userNumber, length, width),
                findSecondIndex(userArray, userNumber, length, width));
            

        }   //использует 2 предыдущих метода, чтобы найти индекс элемента пользователя
    }

}

