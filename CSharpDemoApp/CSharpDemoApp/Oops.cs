using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemoApp
{
    public class Runner
    {
        public void Run()
        {
            Vehicle v = new Car("Alto");

            MoveVechicle(v);

            v = new Bike("Discover");

            MoveVechicle(v);
        }

        static void MoveVechicle(Vehicle vehicle)
        {
            vehicle.Move();
        }
    }

    public interface IStoppable
    {
        void Stop();
    }

    public interface ICkickStart
    {
        void CickStart();
    }


    public abstract class Vehicle : IStoppable
    {
        protected string name;

        public Vehicle(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public virtual void Move()
        {
            Console.WriteLine(this.name + " is moving");
        }

        public void Stop()
        {
            Console.WriteLine("Stopped");
        }
    }

    public class Car : Vehicle
    {
        public Car(string name) : base(name)
        {

        }

        public override void Move()
        {
            throw new Exception("Accident");
        }

        public void Foo()
        {

        }
    }

    public class Bike : Vehicle, ICkickStart
    {
        public Bike(string name) : base(name)
        {

        }

        public void CickStart()
        {
            Console.WriteLine("Cick start");
        }
    }
}
