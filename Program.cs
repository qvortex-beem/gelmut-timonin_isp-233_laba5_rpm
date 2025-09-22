using System;

namespace Фабричный_метод {
    class Program {
        static void Main(string[] args) {
            // Создаем фабрики
            poshta roadPoshta = new RoadPoshta("Наземные перевозки");
            poshta airPoshta = new AirPoshta("Авиа перевозки");

            // Используем фабрики для создания транспорта
            Transport truck = roadPoshta.Create("truck");
            Transport airplane = airPoshta.Create("airplane");
            Transport train = roadPoshta.Create("train");

            truck.Deliver();    // Грузовик доставляет груз по дороге
            airplane.Deliver(); // Самолет доставляет груз по воздуху
            train.Deliver(); // Поезд доставляет груз по рельсам

            Console.ReadLine();
        }
    }

    abstract class poshta {
        public string Name { get; set; }

        public poshta(string n) {
            Name = n;
        }

        // Фабричный метод
        abstract public Transport Create(string type);
    }

    class RoadPoshta : poshta {
        public RoadPoshta(string name) : base(name) { }

        public override Transport Create(string type) {
            if (type == "truck")
            {
                Console.WriteLine("Создан грузовик для: " + Name);
                return new Truck();
            }
            else if (type == "train")
            {
                Console.WriteLine("Создан поезд для: " + Name);
                return new Train();
            }
            else { return null; }
        }
    }

    class AirPoshta : poshta {
        public AirPoshta(string name) : base(name) { }
        public override Transport Create(string type) {
            Console.WriteLine("Создан самолет для: " + Name);
            return new Airplane();
        }
     
    }



    // Интерфейс должен определять поведение
    interface Transport {
        void Deliver();
    }

    class Truck : Transport {
        public void Deliver() {
            Console.WriteLine("Грузовик доставляет груз по дороге");
        }
    }

    class Airplane : Transport {
        public void Deliver() {
            Console.WriteLine("Самолет доставляет груз по воздуху");
        }
    }

    class Train : Transport {
        public void Deliver() {
            Console.WriteLine("Поезд доставляет груз по рельсам");
        }
    }
}
