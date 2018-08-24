using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemoApp
{
    public class DelegateUsage
    {
        public void Use()
        {
            var list = new MyList<int>();

            list.Add(1);
            list.Add(11);
            list.Add(10);
            list.Add(91);

            Console.WriteLine("All");
            var data = list.GetAll();
            Print(data);

            Console.WriteLine("Even");
            var evenNumbers = list.Where(x => x % 2 == 0);
            Print(evenNumbers);

            Console.WriteLine("Odd");
            var odd = list.Where(x => x % 2 != 0);
            Print(odd);
        }

        void Print<T>(T[] data)
        {
            foreach (var d in data)
            {
                if (d.ToString() != "0")
                {
                    Console.WriteLine(d);
                }
            }
        }
    }

    public class MyList<T>
    {
        private T[] data;
        private int iterator = 0;

        public MyList()
        {
            this.data = new T[10];
        }

        public MyList(int size)
        {
            this.data = new T[size];
        }

        public void Add(T d)
        {
            this.data[iterator] = d;
            iterator++;
        }

        public T[] Where(Func<T, bool> filter)
        {
            T[] output = new T[this.data.Length];
            int oIterator = 0;

            for (var i = 0; i < this.data.Length; i++)
            {
                if (filter(this.data[i]))
                {
                    output[oIterator] = this.data[i];
                    oIterator++;
                }
            }

            return output;
        }

        public T[] GetAll()
        {
            T[] output = new T[this.data.Length];
            for (var i = 0; i < this.data.Length; i++)
            {
                output[i] = this.data[i];
            }

            return output;
        }
    }

    
}
