using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            Console.WriteLine(stack.IsEmpty());
            stack.AddRange(new System.Collections.Generic.Stack<string>());
        }
    }
}
