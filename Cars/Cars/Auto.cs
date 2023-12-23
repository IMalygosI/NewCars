using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Car
{
    internal class Auto
    {
        private string? number_Car;//Номер машины
        private double volume_Tank;//Объём бака
        private double consumption_Fuel;//Расход топлива на 100 км
        private int speed;//Скорость
        private double currentamount_Gasoline;//Текущее количество бензина
        private double mileage;//Пробег
        private double kilometers_Enough_Fuel;//На сколько километров хватит топлива
        private double interval; //Расстояние
        private double distance;//Дистанция
        private double koordinata_Xa;//Координата X
        private double koordinata_Ya;//Координата Y
        private double koordinata_Xb;//Координата X
        private double koordinata_Yb;//Координата Y
        public static List<Auto> cars;
        //private List<Auto> cars = new List<Auto>();
        private string? Num_Car
        {
            get { return number_Car; }
        }
        private Auto()
        {
            Choice(cars);
        }
        private void Choice(List<Auto> cars)
        {
            Console.WriteLine("\n>> Mеню:\n> 1 - Создание нового автомобиля\n> 2 - Выбор автомобиля");
            string? Choice = Console.ReadLine();
            switch (Choice)
            {
                case "1":
                    Info(cars);
                    break;
                case "2":
                    СhangeAuto(cars);
                    break;
            }
        }
        private void Info(List<Auto> cars) //Информация об автомобиле
        {
            Console.WriteLine("\n> Выбрать номер машины:\n1- Ввод вручную\n2- Автоматически");
            string? Choice_select_car_number = Console.ReadLine();
            if (Choice_select_car_number == "1")//Номер машины
            {
                Console.WriteLine("> Введите номер машины :");
                this.number_Car = Console.ReadLine();
                Console.WriteLine($"Номер машины : {number_Car}\n");
            }//Номер машины
            if (Choice_select_car_number == "2")//Номер машины
            {
                char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                Random rnd = new Random();
                string word = "";
                for (int j = 1; j <= 4; j++)
                {
                    int letter_num = rnd.Next(0, letters.Length - 1);
                    word += letters[letter_num];
                }
                this.number_Car = word;
                Console.WriteLine($"Номер машины : {number_Car}\n");
            }//Номер машины
            Console.WriteLine("> Введите объем бака :\n1- Ввод вручную\n2- Автоматически");
            string? Choice_select_car_tank_volume = Console.ReadLine();
            if (Choice_select_car_tank_volume == "1")//Объем бака машины
            {
                Console.WriteLine("> Введите объем бака :");
                this.volume_Tank = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Объем бака машины : {volume_Tank}\n");
            }//Объем бака машины
            if (Choice_select_car_tank_volume == "2")//Объем бака машины
            {
                Random rnd = new Random();
                int volume = rnd.Next(70, 90);
                this.volume_Tank = volume;
                Console.WriteLine($"Объем бака машины : {volume_Tank}\n");
            }//Объем бака машины
            Console.WriteLine("> Укажите расход топлива :\n1- Ввод вручную\n2- Автоматически");
            string? Choice_select_car_consumption = Console.ReadLine();
            if (Choice_select_car_consumption == "1")//Расход топлива машины
            {
                Console.WriteLine("Расход топлива (на 100 км):");
                this.consumption_Fuel = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Расход топлива (на 100 км): {consumption_Fuel}\n");
            }//Расход топлива машины
            if (Choice_select_car_consumption == "2")//Расход топлива машины
            {
                Random rnd = new Random();
                int consumption = rnd.Next(8, 17);
                this.consumption_Fuel = consumption;
                Console.WriteLine($"Расход топлива (на 100 км): {consumption_Fuel}\n");
            }//Расход топлива машины
            Console.WriteLine("> Укажите нынешний уровень топлива:\n1- Ввод вручную\n2- Автоматически");
            string? Choice_Current_quantity_gasoline = Console.ReadLine();
            if (Choice_Current_quantity_gasoline == "1")//текущее количество бензина
            {
                Console.WriteLine("Уровень топлива:");
                this.currentamount_Gasoline = Convert.ToDouble(Console.ReadLine());
                if (volume_Tank >= currentamount_Gasoline)
                {

                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline}");
                }
                else
                {
                    this.currentamount_Gasoline = volume_Tank;
                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline}");
                }
            }//текущее количество бензина 
            if (Choice_Current_quantity_gasoline == "2")
            {
                Random rnd = new Random();
                int currentamount = rnd.Next(0, 90);
                this.currentamount_Gasoline = currentamount;
                if (volume_Tank >= currentamount)
                {
                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline}");
                }
                else
                {
                    currentamount_Gasoline = volume_Tank;
                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline}");
                }
            }//текущее количество бензина 
            this.speed = 0;//скорость
            this.interval = 0;//расстояние что проехали
            this.mileage = 0;//пробег
            this.kilometers_Enough_Fuel = 0;//На сколько километров хватит топлива
            Console.WriteLine($"\n|Информация по машине|");
            Out();
            Console.WriteLine("|Автомобиль занесен в базу, можете теперь его выбрать\n");
        }
        private void Path_Information(List<Auto> cars) // вводим информацию по пути 
        {
            Console.WriteLine("> Введите координаты вашего пути");
            Console.WriteLine("Начало-Xa: ");
            this.koordinata_Xa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Начало-Ya: ");
            this.koordinata_Xa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Конец-Xb: ");
            this.koordinata_Xb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Конец-Yb: ");
            this.koordinata_Yb = Convert.ToInt32(Console.ReadLine());
            distance = Math.Sqrt(((koordinata_Xb - koordinata_Xa) * (koordinata_Xb - koordinata_Xa)) + ((koordinata_Yb - koordinata_Ya) * (koordinata_Yb - koordinata_Ya)));
            distance = Convert.ToInt32(distance);
            Console.WriteLine("> Данные внесены");
            Console.WriteLine($"Цель поездки проехать {distance} км");
            Console.WriteLine($"объем бака и уровень топлива в машине:\nбак: {volume_Tank} Литров\nТопливо: {currentamount_Gasoline} Литров\n");
            this.interval = 0;
            Menu(cars);
        }
        private void Stop(List<Auto> cars)//Остановка
        {
            speed = 0;
            interval = 0;
            Console.WriteLine($"\n> Вы остановились\n");
            Console.WriteLine($"> Пробег автомобиля: {mileage} км");
            Console.WriteLine($"> Вы желаете продолжить или закончить путь ?\n1 - Продолжить\n2 - Закончить\n");
            string? vybor = Console.ReadLine();
            if (vybor == "1")
            {
                Console.WriteLine($"> Номер авто: {number_Car}");
                Console.WriteLine($"> Пробег автомобиля: {mileage} км");
                Drive(cars);
            }
            else if (vybor == "2")
            {
                Console.WriteLine($"> Номер авто: {number_Car}");
                Console.WriteLine($"> Пробег автомобиля: {mileage} км");
                Choice(cars);
            }
        }
        private void Razgon(List<Auto> cars) //Разгон
        {
            if (distance == 0)
            {
                Console.WriteLine("Цель поездки не задана!");
                Choice(cars);
            }
            else if (distance > 0)
            {
                if (currentamount_Gasoline > 0)//Проверяем наличие бензина
                {
                    speed = 100;
                    Drive(cars);
                    Choice(cars);
                }
                else if (currentamount_Gasoline <= 0)
                {
                    interval = 0;
                    Console.WriteLine("Бак пуст");
                    Console.WriteLine($"Требуется заправка !");
                    Console.WriteLine("> Заправиться? (1 - Да, 2 - Нет)\n");
                    string? zapravim = Console.ReadLine();
                    switch (zapravim)
                    {
                        case "1":
                            Zapravka(cars);
                            break;
                        case "2":
                            Stop(cars);
                            break;
                    }
                }
            }
        }
        private void Crash(List<Auto> cars)//АВАРИЯ
        {
            if (cars.Count == 1)
            {
                Console.WriteLine("Аварии невозможна! рядом нет других машин!");
                Menu(cars);
            }
            else if (cars.Count > 1)
            {
                Random random = new Random();
                var random1 = random.Next(0, cars.Count);
                var random2 = random.Next(0, cars.Count);

                for (int i = 0; i < cars.Count; i++) //Для машины 1
                {
                    for (int j = 0; j < cars.Count; j++) // Для машины 2
                    {
                        if (i != j)
                        {
                            if ((cars[i].koordinata_Xa == cars[j].koordinata_Xa && cars[i].koordinata_Xb == cars[j].koordinata_Xb)
                             && (cars[i].koordinata_Ya == cars[j].koordinata_Ya && cars[i].koordinata_Xb == cars[j].koordinata_Xb))//сравниваем координаты двух автомобилей
                            {
                                cars[i] = cars[random1];
                                cars[j] = cars[random2];
                                Console.WriteLine("Aвтомобили столкнулись!)");
                                cars[i].speed = 0;
                                cars[j].speed = 0;
                                cars[i].interval = 0;
                                cars[j].interval = 0;
                                cars[i].distance = 0;
                                cars[j].distance = 0;
                                Choice(cars);
                            }
                            else
                            {
                                Console.WriteLine("Аварии сегодня не будет(?\n");
                                Menu(cars);
                            }
                        }
                    }
                }
            }
        }
        private void Drive(List<Auto> cars) // Метод езды автомобиля
        {
            if (speed > 0)//если скорость бошльше 0
            {
                if (currentamount_Gasoline > 0)  //currentamount_Gasoline - Текущее количество бензина /  если топлива бошльше 0
                {
                    currentamount_Gasoline -= consumption_Fuel;
                    mileage += 100;
                    interval += 100;
                }
                else if ((currentamount_Gasoline - consumption_Fuel) < 0 & speed > 0)
                {
                    mileage -= 100;
                    interval -= 100;
                    mileage += kilometers_Enough_Fuel;
                    interval += kilometers_Enough_Fuel;
                    currentamount_Gasoline = 0;
                }
                else if (currentamount_Gasoline == 0 || currentamount_Gasoline < consumption_Fuel)
                {
                    interval = 0;
                    Console.WriteLine("Требуется заправка!");
                    Console.WriteLine("> Заправиться? (1 - Да / 2 - Нет)\n");
                    string? zapravim = Console.ReadLine();
                    switch (zapravim)
                    {
                        case "1":
                            Zapravka(cars);
                            break;
                        case "2":
                            Stop(cars);
                            break;
                    }
                }
            }
            if (interval >= distance && distance != 0) //Для цели поездки
            {
                double v = distance - (interval - 100);
                currentamount_Gasoline = (v * consumption_Fuel) / 100;
                mileage += v - 100;
                speed = 0;
                distance = 0;
                interval = 0;
                Console.WriteLine("Вы выполнили цель поездки!");
                Console.WriteLine($"> Желаете Задать новую цель или закончить путь ?\n1 - Новая цель\n2 - Закончить путь\n");
                string? vybor = Console.ReadLine();
                if (vybor == "1")
                {
                    Console.WriteLine($"> Номер авто: {number_Car}");
                    Console.WriteLine($"> Пробег автомобиля: {mileage} км");
                    Path_Information(cars);
                }
                else if (vybor == "2")
                {
                    Console.WriteLine($"> Номер авто: {number_Car}");
                    Console.WriteLine($"> Пробег автомобиля: {mileage} км");
                    Choice(cars);
                }
            }
            if (currentamount_Gasoline < 2 && interval < distance && interval != 0)
            {
                mileage += kilometers_Enough_Fuel - 100;
                interval += kilometers_Enough_Fuel - 100;
                currentamount_Gasoline = 0;
                speed = 0;
            }
            kilometers_Enough_Fuel = Math.Round((currentamount_Gasoline / consumption_Fuel) * 100); //На сколько километров хватит бензина
            Console.WriteLine($"\n> Вы проехали: {interval} км");// Интервал это то сколько -за раз едем, если остановаится он сбрасывается до 0 ну пробег все еще остается!
            Console.WriteLine($"> Cколько проедем при текущем уровне бензина в баке: {kilometers_Enough_Fuel} км");
            Console.WriteLine($"> Сейчас в баке: {currentamount_Gasoline} литров");
            Console.WriteLine($"> Необходимо проехать: {distance} км");
            Console.WriteLine($"> Пробег автомобиля: {mileage} км");
            Console.WriteLine($"> Вы ехали со скоростью: {speed} км\n");
            if (currentamount_Gasoline == 0)
            {
                Console.WriteLine("Требуется заправка!");
                Console.WriteLine("> Заправиться? (1 - Да, 2 - Нет)\n");
                string? zapravim = Console.ReadLine();
                switch (zapravim)
                {
                    case "1":
                        Zapravka(cars);
                        break;
                    case "2":
                        Stop(cars);
                        break;
                }
            }
            else
            {
                Menu(cars);
            }
        }
        private double Zapravka(List<Auto> cars) //Заправка
        {
            speed = 0;
            Console.WriteLine($"> Сколько литров Вы хотите заправить в бак?\n" +
            $"> Объем бака автомобиля: {volume_Tank},\n> Нынешний уровень топлива в автомобиле: {currentamount_Gasoline} литров.");

            double zapravim = Convert.ToDouble(Console.ReadLine());
            if ((currentamount_Gasoline + zapravim) <= volume_Tank) //Условие на случай переполнения бака
            {
                currentamount_Gasoline += zapravim;
                Console.WriteLine($"Автомобиль заправлен. Сейчас в машине: {currentamount_Gasoline} литров.");
                Menu(cars);
            }
            else
            {
                currentamount_Gasoline = volume_Tank;
                Console.WriteLine($"\nВы заливаете слишком многоЙ! излишки убраны");
                Console.WriteLine($"Ваш автомобиль заправлен. Сейчас в машине: {currentamount_Gasoline} литров.");
                Menu(cars);
            }
            return currentamount_Gasoline;
        }
        private void Out()//Вывод информации
        {
            Console.WriteLine($"\n|Номер авто: {number_Car}" +
                              $"\n|Объём бака: {volume_Tank}" +
                              $"\n|Уровень топлива: {currentamount_Gasoline}" +
                              $"\n|Расход топлива: {consumption_Fuel}" +
                              $"\n|Пробег автомобиля: {mileage}");// за все время, ведь пробег же
        }
        private void Menu(List<Auto> cars)//меню выбора
        {
            Console.WriteLine(">> Меню:" +
                             "\n> 1 - Задать цель поездки" +//Выбираем начало и конец координат пути, для определения дистанции пути
                             "\n> 2 - Газ" +
                             "\n> 3 - Останавливаемся" +
                             "\n> 4 - Заправиться" +
                             "\n> 5 - Сменить автомобиль" +
                             "\n> 6 - Вызывть справку по машине" +
                             "\n> 7 - АВАРИЯ");

            string? vybor = Console.ReadLine();
            switch (vybor)
            {
                case "1":
                    Path_Information(cars);
                    break;
                case "2":
                    Razgon(cars);
                    break;
                case "3":
                    Stop(cars);
                    break;
                case "4":
                    Zapravka(cars);
                    break;
                case "5":
                    Choice(cars);
                    break;
                case "6":
                    Out();
                    Menu(cars);
                    break;
                case "7":
                    Crash(cars);
                    break;
            }
        }
        public static void СhangeAuto(List<Auto> cars)
        {
            Auto car;
            while (true)
            {
                Console.WriteLine(">> Меню:\n1 - Создать автомобиль\n2 - Выбрать автомобиль");
                string? vybor = Console.ReadLine();
                if (vybor == "1")
                {
                    cars.Add(new Auto());
                }
                else if (vybor == "2")
                {
                    foreach (Auto auto in cars)
                    {
                        Console.WriteLine("Введите номер автомобиля: ");
                        string? number = Console.ReadLine();
                        if (number == auto.Num_Car)
                        {
                            car = auto;
                            car.Menu(cars);
                        }
                    }
                }
            }
        }
    }
}
