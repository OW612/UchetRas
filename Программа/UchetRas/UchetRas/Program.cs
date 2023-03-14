using System;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Threading.Channels;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace MyProgram
{
    class Departaments//Класс отделов
    {
        public string NameDepartament;//Название отдела
        public int KolvoSotrudnikov;//Количество сотрудников

        public void NDep()//определение отдела
        {
            ConsoleKeyInfo depart;//переменная для выбора отдела
            Console.WriteLine("Выберите ваш отдел:\n\tF1 - Коммерческий\n\tF2 - Рекламный\n\tF3 - Технический\n\tF4 - Финансовый\n\tF5 - Юридический");
            Console.WriteLine("\nНажмите кнопку вашего отдела: ");
            while (true)
            {
                depart = Console.ReadKey(true);
                if ((depart.Key == ConsoleKey.F1) || (depart.Key == ConsoleKey.F2) || (depart.Key == ConsoleKey.F3) || (depart.Key == ConsoleKey.F4) || (depart.Key == ConsoleKey.F5))
                {
                    if (depart.Key == ConsoleKey.F1)
                    {
                        NameDepartament = "Коммерческий";
                        KolvoSotrudnikov = 25;
                        break;
                    }

                    if (depart.Key == ConsoleKey.F2)
                    {
                        NameDepartament = "Рекламный";
                        KolvoSotrudnikov = 16;
                        break;
                    }

                    if (depart.Key == ConsoleKey.F3)
                    {
                        NameDepartament = "Технический";
                        KolvoSotrudnikov = 18;
                        break;
                    }

                    if (depart.Key == ConsoleKey.F4)
                    {
                        NameDepartament = "Финансовый";
                        KolvoSotrudnikov = 30;
                        break;
                    }

                    if (depart.Key == ConsoleKey.F5)
                    {
                        NameDepartament = "Юридический";
                        KolvoSotrudnikov = 27;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверная кнопка, посмотрите информацию о доступных кнопках!\n");
                }
            }
            Console.WriteLine("Отдел - " + NameDepartament + ", Количество сотрудников - " + KolvoSotrudnikov);
        }
            
    }

    class TypesOfExpenses//Класс видов расходов
    {
        public string NameExpenses;//Название расходов
        public string Description;//Описание
        public double PredelNorma;//Предельная норма    

        public void TOExp()//определение вида расходов
        {
            ConsoleKeyInfo typeexp;//переменная для выбора вида расходов
            Console.WriteLine("\nВыберите вид расходов:\n\tF1 - Канцелярия\n\tF2 - Ремонт офисной техники\n\tF3 - Сеть\n\tF4 - Мебель\n\tF5 - Удобства сотрудников");
            Console.WriteLine("\nНажмите кнопку вида расходов: ");
            while (true)
            {
                typeexp = Console.ReadKey(true);
                if ((typeexp.Key == ConsoleKey.F1) || (typeexp.Key == ConsoleKey.F2) || (typeexp.Key == ConsoleKey.F3) || (typeexp.Key == ConsoleKey.F4) || (typeexp.Key == ConsoleKey.F5))
                {
                    if (typeexp.Key == ConsoleKey.F1)
                    {
                        NameExpenses = "Канцелярия";
                        Description = "Расходы на канцтовары(бумага, ручки, карандаши, клей, степлеры, дыроколы, и т.д.)";
                        PredelNorma = 500;
                        break;
                    }

                    if (typeexp.Key == ConsoleKey.F2)
                    {
                        NameExpenses = "Ремонт офисной техники";
                        Description = "\tРасходы на починку офисной техники(компьютеры, принтеры, ксероксы, телефоны, пылесосы и т.д.)";
                        PredelNorma = 800;
                        break;
                    }

                    if (typeexp.Key == ConsoleKey.F3)
                    {
                        NameExpenses = "Сеть";
                        Description = "Расходы на сеть(покупка новых тарифов, оплата хостинга, интернета, антивируса и т.д.)";
                        PredelNorma = 700;
                        break;
                    }

                    if (typeexp.Key == ConsoleKey.F4)
                    {
                        NameExpenses = "Мебель";
                        Description = "Расходы на мебель(покупка новой мебели, ремонт мебели)";
                        PredelNorma = 1000;
                        break;
                    }

                    if (typeexp.Key == ConsoleKey.F5)
                    {
                        NameExpenses = "Удобства сотрудников";
                        Description = "Расходы на удобства сотрудников(покупка кондиционеров, кулеров, бутилированной воды, кофемашин, электрочайников и т.д.)";
                        PredelNorma = 550;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверная кнопка, посмотрите информацию о доступных кнопках!\n");
                }
            }
            Console.WriteLine("\tВид расходов - " + NameExpenses + "\n\tОписание: " + Description + "\n\tПредельная норма расходов - " + PredelNorma);
        }
    }
 
    class Expenses//Класс расходов
    {
        public string TypeExp;//Вид расходов
        public string Depart;//Отдел
        public double Summa;//Сумма
        public string Date;//Дата    

        public void Expens(string NameDepartament, string NameExpenses, double PredelNorma)
        {
            TypeExp = NameExpenses;
            Depart = NameDepartament;

            DateTime adate;//переменная для проверки правильности даты
            CultureInfo provider = CultureInfo.InvariantCulture;//проверка даты в соответствии с регионом
            string format = "dd.MM.yyyy";//формат даты

            //Ввод и проверка даты
            while (true)
            {
                Console.Write("\nВведите дату в формате 'DD.MM.YYYY': ");
                Date = Console.ReadLine();
                try
                {
                    adate = DateTime.ParseExact(Date, format, provider);//Попытка привести введенную дату к правильному формату даты
                    break;
                }
                catch
                {
                    Console.WriteLine("Дата введена некорректно! Попробуйте еще раз.");
                }
            }

            StreamReader filedate = new StreamReader("data\\Отделы\\"+NameExpenses +".txt");//поток чтения для определения наличия месяца в записи данных
            string checkdate;//переменная даты в текстовом файле
            int k = 0;//переменная для определения наличия даты в текстовом файле данных
            while (!filedate.EndOfStream)
            {
                checkdate = (filedate.ReadLine()).Substring(0, 7);//берем номера символов, которые хранят дату
                if (Date.Substring(3) == checkdate) k = 1;
            }//определение есть ли данный месяц и год в текстовом файле данных
            filedate.Close();

            //добавление в текстовый файл данных даты если она отсутствует
            if (k == 0)
            {
                string y1 = "\n" + Date.Substring(3) + "  мес:0";
                File.AppendAllText("data\\Отделы\\" + NameExpenses + ".txt", y1); 
                string m1 = "data\\Отделы\\Канцелярия.txt";
                string m2 = "data\\Отделы\\Мебель.txt";
                string m3 = "data\\Отделы\\Ремонт офисной техники.txt";
                string m4 = "data\\Отделы\\Сеть.txt";
                string m5 = "data\\Отделы\\Удобства сотрудников.txt";
                string[] massiv = { m1, m2, m3, m4, m5 };
                for (int i = 0; i < 5; i++)//цикл чтения суммы из 5 разных файлов
                {
                    File.AppendAllText(massiv[i], y1);
                }
                Console.WriteLine("Добавлена новая дата");
            }

            //Ввод и проверка суммы расходов
            string hj;//переменная хранения прошлой суммы
            while (true)
            {
                try
                {
                    Console.Write("\nВведите сумму расходов: ");
                    Summa = double.Parse(Console.ReadLine());
                    if ((Summa + double.Parse(File.ReadAllLines("data\\Отделы\\" + NameExpenses + ".txt").Last().Substring(13))) > PredelNorma)
                    {
                        Console.WriteLine("\nСумма расходов превышает предел на {0}! Введите другое значение.", (Summa + double.Parse((File.ReadAllLines("data\\Отделы\\" + NameExpenses + ".txt").Last()).Substring(13))) - PredelNorma);
                    }
                    else
                    {
                        if (Summa < 0) Console.WriteLine("Неккоректный ввод суммы!");
                        else
                        {
                            hj = File.ReadAllLines("data\\Отделы\\" + NameExpenses + ".txt").Last().Substring(13);
                            hj = File.ReadAllLines("data\\Отделы\\" + NameExpenses + ".txt").Last().Substring(0, 13) + Convert.ToString(double.Parse(hj) + Summa);
                            var lines = File.ReadAllLines("data\\Отделы\\" + NameExpenses + ".txt");
                            File.WriteAllLines("data\\Отделы\\" + NameExpenses + ".txt", lines.Take(lines.Length - 1).ToArray());//перезапись того же файла, но без последней строки
                            File.AppendAllText("data\\Отделы\\" + NameExpenses + ".txt", hj);
                            break;
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }

            Console.WriteLine("\n\tПокупка оформлена!");
        }

    }

    class Program
    {
        static void Info()
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("|\t\t\tУЧЕТ ВНУТРИОФИСНЫХ РАСХОДОВ\t\t\t\t|");
            Console.WriteLine("| Действия:\t\t\t\t\t\t\t\t\t|");
            Console.WriteLine("|\tНажмите 'F1', чтобы закрыть программу\t\t\t\t\t|");
            Console.WriteLine("|\tНажмите 'F2', если хотите очистить консоль\t\t\t\t|");
            Console.WriteLine("|\tНажмите 'F3', если хотите посмотреть информацию о кнопках\t\t|");
            Console.WriteLine("|\tНажмите 'F4', если хотите оформить отчет о покупке\t\t\t|");
            Console.WriteLine("|\tНажмите 'F5', если хотите посмотреть информацию о всех расходах\t\t|");
            Console.WriteLine("---------------------------------------------------------------------------------");
        }

        static void Buy()//метод для покупки
        {
            Departaments dep = new Departaments();
            TypesOfExpenses toexpen = new TypesOfExpenses();
            Expenses expen = new Expenses();

            Console.WriteLine("купить");
            dep.NDep();
            toexpen.TOExp();
            expen.Expens(dep.NameDepartament, toexpen.NameExpenses, toexpen.PredelNorma);
        }

        static void Show()//Метод для вывода расходов
        {
            double money = 0;
            string ras;
            string m1 = "data\\Отделы\\Канцелярия.txt";
            string m2 = "data\\Отделы\\Мебель.txt";
            string m3 = "data\\Отделы\\Ремонт офисной техники.txt";
            string m4 = "data\\Отделы\\Сеть.txt";
            string m5 = "data\\Отделы\\Удобства сотрудников.txt";
            string[] mass = {m1, m2, m3, m4, m5};//массив путей хранения файлов содержащих суммы затрат

            ras = File.ReadAllLines(mass[0]).Last();
            char[] Mychar = { '.', 't', 'x', 't' };//Символы которые будут удалены
            Console.WriteLine("\nСумма расходов на {0}:", ras.Substring(0, 7));
            for (int i = 0; i < 5; i++)//цикл чтения суммы из 5 разных файлов
            {
                ras = File.ReadAllLines(mass[i]).Last();//считывание последней строки из файлов
                Console.WriteLine("\tРасходы на {0}: {1}", (mass[i].Substring(12)).TrimEnd(Mychar), ras.Substring(13));//Вывод суммы расходов на конкретные виды расходов
                money += double.Parse(ras.Substring(13));//прибавление суммы расходов из текстового файла на начиная с 7 символа(откуда начинается сумма)
            }
            Console.WriteLine("\nОбщие внутриофисные расходы составляют: " + money);
        }

        static void Main()
        {
            ConsoleKeyInfo action;//Действие на нажатие клавиши
            Info();
            while (true)
            {
                Console.Write("\nВвод действия: ");
                action = Console.ReadKey(true);

                if ((action.Key == ConsoleKey.F1) || (action.Key == ConsoleKey.F2) || (action.Key == ConsoleKey.F3) || (action.Key == ConsoleKey.F4) || (action.Key == ConsoleKey.F5))
                {
                    if (action.Key == ConsoleKey.F1) break;

                    if (action.Key == ConsoleKey.F2)
                    {
                        Console.Clear();
                        Info();
                        Console.WriteLine("\nКонсоль очищена!");
                    }

                    if (action.Key == ConsoleKey.F3) Info();

                    if (action.Key == ConsoleKey.F4) Buy();

                    if (action.Key == ConsoleKey.F5) Show();
                }
                else
                {
                    Console.WriteLine("Неверная кнопка, посмотрите информацию о доступных кнопках!");
                }
            }
        }
    }
    
}