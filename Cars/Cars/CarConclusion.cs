using Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class CarConclusion
{
    static void Main(string[] args)
    {
        List<Auto> cars = new List<Auto>();
        while (true)
        {
            Console.WriteLine("\n>> Mеню:\n> 1 - Создание нового автомобиля\n> 2 - Выбор автомобиля");
            string? Choice = Console.ReadLine();
            if (Choice == "1")
            {
                cars.Add(new Auto(cars));
            }
            else if (Choice == "2")
            {
                Auto car;
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
