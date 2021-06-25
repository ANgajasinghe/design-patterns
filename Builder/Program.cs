using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new CarBuilder();
            BuidMyCar(builder);

            builder.build().Dump();

        }

        public static void BuidMyCar(ICarBuilder builder) 
        {
            builder
                .SetName("ABC")
                .SetPrice(120.00)
                .SetCreatedDate(DateTime.Now);
        }
       
    }

    // we going to buikder a CAR




    public interface ICarBuilder 
    {
        public ICarBuilder SetName(string name);
        public ICarBuilder SetPrice(double price);
        public ICarBuilder SetCreatedDate(DateTime data);


 
    }

    public class CarBuilder : ICarBuilder
    {
        private Car _car = new Car();

        public ICarBuilder SetCreatedDate(DateTime data)
        {
            _car.CreatedDate = data;
            return this;
        }

        public ICarBuilder SetName(string name)
        {
            _car.Name = name;
            return this;
        }

        public ICarBuilder SetPrice(double price)
        {
            _car.Price = price;
            return this;
        }

        public Car build() => _car;
    }



    public class Car
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
