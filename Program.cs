using System;

namespace Circular_reference_dependency_solutions
{

    // public class ClassA
    // {
    //     public void callFriends(object sender, EventArgs e)
    //     {
    //         Console.WriteLine("calling friends");
    //     }
    // }

    // public class ClassB
    // {
    //     public ClassA a_Instance = new ClassA();
    //     public event EventHandler callingFriends;

    //     public ClassB()
    //     {
    //         callingFriends += a_Instance.callFriends;
    //     }

    //     public void maikingCoffee()
    //     {
    //         Console.WriteLine("makingCoffee");
    //         callingFriends.Invoke(this, EventArgs.Empty);
    //     }
    // }

    public interface callingFriends
    {
        void callFriends();

    }
    public interface makingCoffee
    {
        void makeCoffee();

    }

    public class ClassA : callingFriends
    {
        public void callFriends()
        {
            Console.WriteLine("calling friends");
        }
    }

    public class ClassB : makingCoffee
    {
        public callingFriends i_instance = new ClassA();
        public void makeCoffee()
        {
            Console.WriteLine("makingCoffee");
            i_instance.callFriends();
        }
    }
    class Program
    {
        static ClassB instance = new ClassB();
        static void Main(string[] args)
        {
            instance.makeCoffee();
        }
    }
}
