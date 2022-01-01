using System;

namespace InheritanceExample
{
    class Program
    {
        public class Animal
        {
            public string Name { get; set; } = "Dafault animal";
        }
        public class Dog : Animal
        {
            public string Test { get; set; }
        }

        static void Main(string[] args)
        {
            var a = new Animal() ;
            var d = new Dog() { Name = "Dog", Test = "Test" };


            //var ad = (Dog)a; //Unable to cast object of type 'Animal' to type 'Dog'
            //Dog dd = (Dog)new Animal(); //Unable to cast object of type 'Animal' to type 'Dog'
            
            Animal aa = new Dog();
            Console.WriteLine($"New Dog as Animal, name {aa.Name}");

            Animal da = (Animal)d;
            Console.WriteLine($"Dog cast as Animal, name {da.Name}, test unavailable");

            var dad = (Dog)da;
            Console.WriteLine($"Dog from Animal created as Dog, name {dad.Name}, test {dad.Test}");
        }
    }
}
