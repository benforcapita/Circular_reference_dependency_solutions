using System;

namespace Circular_reference_dependency_solutions
{

    public class ClassA
    {
        public void callFriends(object sender, EventArgs e)
        {
            Console.WriteLine("calling friends");
        }
    }

    public class ClassB
    {
        public ClassA a_Instance = new ClassA();
        public event EventHandler callingFriends;

        public ClassB()
        {
            callingFriends += a_Instance.callFriends;
        }

        public void maikingCoffee()
        {
            Console.WriteLine("makingCoffee");
            callingFriends.Invoke(this, EventArgs.Empty);
        }
    }
    class Program
    {
        static ClassB instance = new ClassB();
        static void Main(string[] args)
        {
            instance.maikingCoffee();
        }
    }
}
