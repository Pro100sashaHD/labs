using System;
using System.Collections.Generic;
namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine().Replace(" ", "");
            string num_buffer = "";
            List<int> nums = new List<int>();
            List<char> ops = new List<char>();
            int i = 0;
            for (; i < str.Length; i++)
            {
                bool parsable = int.TryParse(Char.ToString(str[i]), out _);
                if (parsable == false)
                {
                    ops.Add(str[i]);
                    nums.Add(int.Parse(num_buffer));
                    num_buffer = "";
                }
                else
                {
                    num_buffer += Char.ToString(str[i]);
                }
            }
            if (!string.IsNullOrEmpty(num_buffer))
            {
                nums.Add(int.Parse(num_buffer));
            }
            foreach (char op in ops)
            {
                Console.Write(op.ToString() + " ");
            }
            Console.WriteLine();
            foreach (int num in nums)
            {
                Console.Write(num.ToString() + " ");
            }
        }
    }
}
