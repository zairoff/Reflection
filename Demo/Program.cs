using System;
using System.Linq;
using System.Reflection;

namespace Demo
{
    public interface B
    {
        void Test();
    }

    public interface C
    {
        void Print();
    }

    class A : C
    {
        private readonly B testB;
        public void Print()
        {
            throw new NotImplementedException();
        }

        public void Test()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var tp in assembly.GetTypes())
            {
                Console.WriteLine("aa " + tp);
                var infs = tp.GetTypeInfo().GetInterfaces();
                foreach (var inf in infs)
                    Console.WriteLine(inf);
            }
        }

        public void Test()
        {

        }
    }
}
